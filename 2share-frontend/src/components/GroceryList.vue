<template>
    <div class="col">
        <ul class="list-group">
        <li class="list-group-item active rounded-0">{{groceryList && groceryList.Name || ''}}
            <svg v-on:click="saveGroceryList()" width="1.5em" height="1.5em" viewBox="0 0 16 16" class="bi bi-check-circle-fill pull-right" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                <path fill-rule="evenodd" d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z"/>
            </svg>
        </li>
        </ul>
        <ul class="list-group" v-for="product in groceryList.Products" v-bind:key="product.ProductID">
            <li class="list-group-item rounded-0" v-on:click="tag(product)" >{{product.Product.Name}}
                <svg v-on:click="remove(product)" width="1.5em" height="1.5em" viewBox="0 0 16 16" class="bi bi-x pull-right" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                    <path fill-rule="evenodd" d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
                </svg>
                <svg v-if="product.Tagged" width="1.5em" height="1.5em" viewBox="0 0 16 16" class="bi bi-tags-fill pull-right"  fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd" d="M3 1a1 1 0 0 0-1 1v4.586a1 1 0 0 0 .293.707l7 7a1 1 0 0 0 1.414 0l4.586-4.586a1 1 0 0 0 0-1.414l-7-7A1 1 0 0 0 7.586 1H3zm4 3.5a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0z"/>
                        <path d="M1 7.086a1 1 0 0 0 .293.707L8.75 15.25l-.043.043a1 1 0 0 1-1.414 0l-7-7A1 1 0 0 1 0 7.586V3a1 1 0 0 1 1-1v5.086z"/>
                </svg>
            </li>
        </ul>
    </div>    
</template>

<script>
  import axios from 'axios';
  import EventBus from '../eventBus'

  export default {
    name: 'GroceryList',
    data() {
      return {
        groceryList: null,
        message: null,
        processingSave: false
      };
    },
    //Consumes the endpoint designated to get the grocery list data.
    //This method is executed when the component is ready to interact
    //with the user.
    created: function() {
      axios
        .get(process.env.VUE_APP_BASE_ENDPOINT_URL + process.env.VUE_APP_GROCERY_LIST_ENDPOINT)
        .then(res => {
          this.groceryList = res.data;
        })
    },
    methods: {
        //Method to tag a product
        tag: function (product) {
        // `this` inside methods points to the Vue instance
            product.Tagged = !product.Tagged
        },
        //Method to remove a product from the grocery list
        remove: function(product){
            var index = this.groceryList.Products.indexOf(product)
            if (index > -1) {
                this.groceryList.Products.splice(index, 1);
            }
        },
        //Add the selected product to the grocery list 
        addProduct: function(product){

            //If product is in the grocery list emits a message to the App component
            if(this.productInGroceryList(product)){
                this.emitMessage("The product " + product.Name + " is already in your grocery list",1);
                return;
            }

            var newProduct = {
                GroceryListID: this.groceryList.GroceryListID,
                Product: { Name:product.Name, ProductID:product.ProductID },
                ProductID: product.ProductID,
                Tagged:false
            };

            newProduct === null;
            this.groceryList.Products.push(newProduct);
        },
        //Check if a product is already in the grocery list
        productInGroceryList: function(newProduct){
            return this.groceryList.Products.some( product => product.ProductID === newProduct.ProductID);
        },
        //Method to emit a message to the App component
        emitMessage: function(message,status) {
            this.$emit('emitMessage', message,status)
        },
        //Saves the changes in the grocery list.
        saveGroceryList: function(){
            //Check if there is a pending operation.
            if(this.processingSave === true) {
                console.log("Grocery list update is still processing. Please wait.");
                return;
            }

            let newGroceryList = this.getGroceryList();
            //Set the current operation as pending
            this.processingSave = true;

            axios({
                method: 'post',
                url: 'http://localhost:57284/api/grocery/',
                data: newGroceryList,
                })
                .then(response => {
                    //handle success
                    console.log("Success: " + response);
                    this.$emit('emitMessage', "Grocery list was updated successfully.",0);

                })
                .catch(response => {
                    //Log and handle error
                    console.log("Error: " + response);
                    this.$emit('emitMessage', "An error ocurred. Grocery list couldn't be updated.",1);
                });
            //Set current operation as completed
            this.processingSave = false;
            
        },
        //Returns the proper grocery list object to post the grocery list
        //to the API for updating.
        getGroceryList: function(){

            return  {
                GroceryListID: this.groceryList.GroceryListID,
                Products: this.groceryList.Products.map(obj => ({
                    ProductID: obj.ProductID,
                    Tagged: obj.Tagged
                }))
            };
        }


    },
    mounted () {
    EventBus.$on('AddProductEvent', (product) => {
      this.addProduct(product);
    })
  }
  }
</script>