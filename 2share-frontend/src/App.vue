<!-- This is the main component in the app, the template provides the
proper elements to display available products and grocery lists components.   -->
<template>
  <div id="app">
      <div class="container mt-5">
            <div v-bind:class="[ this.statusCode === 0 ? successClass : errorClass ]" class="alert fade show" v-if="this.visibleMessage" role="alert">
              {{validationMessage}}
            </div>
            <div class="row">
              <grocery-list v-on:emitMessage="showMessage"></grocery-list>
              <available-product></available-product>
            </div>
        </div>
  </div>
</template>

<script>
import AvailableProduct from './components/AvailableProduct.vue'
import GroceryList from './components/GroceryList.vue'
export default {
  name: 'App',
  components: {
    AvailableProduct,
    GroceryList
  },
  data() {
    return {
      validationMessage: '',
      successClass: 'alert-success',
      errorClass: 'alert-danger',
      statusCode: 0,
      visibleMessage: null,
    }
  },
  methods:{
    //Shows a message when an operation is performed indicating .
    showMessage: function(message,status){
        this.validationMessage = message;
        this.statusCode = status
        this.visibleMessage = true
        this.InitializeMessage();
    },
    //Changes the data members of the component to hide the message after 4 seconds
    InitializeMessage() {
        setTimeout(() => {
          this.visibleMessage = false;
          this.validationMessage = ""; 
        },4000)
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
