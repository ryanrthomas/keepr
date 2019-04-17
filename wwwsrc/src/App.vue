<template>
  <div id="app">
    <navbar></navbar>
    <router-view />
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue"
  export default {
    name: "login",
    mounted() {
      // Checks for valid session
      this.$store.dispatch("authenticate");
    },
    data() {
      return {
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      };
    },
    methods: {
      register() {
        this.$store.dispatch("register", this.newUser);
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
      }
    },
    components: {
      Navbar
    }
  };
</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    /* background-image: url("https://i0.wp.com/faircastinc.com/wp-content/uploads/2018/06/AdobeStock_100636545-1.jpeg?ssl=1"); */
    background-image: url("http://sf.co.ua/14/09/wallpaper-1341205.jpg");
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>