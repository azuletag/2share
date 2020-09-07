<!-- This component is responsible for retrieving the available 
products by consuming the designated endpoint and showing in an 
HTML template the response returned from the API.  -->
<template>
    <div class="col">
        <ul class="list-group">
          <li class="list-group-item active rounded-0">Available Products</li>
        </ul>
        <ul class="list-group" v-for="product in products" v-bind:key="product.productId">               
            <li class="list-group-item rounded-0" v-on:click="addToGroceryList(product)">{{product.Name}}</li>
        </ul>
    </div>
</template>

<script>
  import axios from 'axios';
  import EventBus from '../eventBus'

  export default {
    name: 'AvailableProduct',
    data() {
      return {
        products: null,
      };
    },
    //This method is executed when the component is created in the DOM.
    //Requests available products from the API.
    created: function() {
      axios
        .get(process.env.VUE_APP_BASE_ENDPOINT_URL + process.env.VUE_APP_PRODUCTS_ENDPOINT)
        .then(res => {
          this.products = res.data;
        })
    },
    
    methods: {
        //Emits a notification to GrecertList component in order to
        //add a new product to the grocery list.
        addToGroceryList: function (product) {
            EventBus.$emit('AddProductEvent', product)
        },
    }
  }
</script>

<style>
  h3 {
    margin-bottom: 5%;
  }
</style>

