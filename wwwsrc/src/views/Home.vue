<template>
  <div class="home text-center container-fluid">
    <h1 class="mt-2">Welcome, {{username}}.</h1>
    <h4>You can post keeps and manage your vaults here.</h4>
    <div class="row d-flex justify-content-center">
      <form name="input-form" class="form-group col-md-5 text-center" @submit.prevent="addKeep">
        <input class="form-control m-2" type="text" v-model="newKeep.name" placeholder="Title" required><br>
        <input class="form-control m-2" type="text" v-model="newKeep.description" placeholder="Description"><br>
        <input class="form-control m-2" type="text" v-model="newKeep.img" placeholder="Image URL"><br>
        <button type="submit" class="btn btn-success mb-3">Post Keep</button>
      </form>
    </div>
    <list-keeps></list-keeps>
  </div>
</template>

<script>
  import ListKeeps from "@/components/ListKeeps.vue"
  export default {
    name: "home",
    mounted() {
      // Blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch('getKeeps')
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          userId: 1,
          shares: 0,
          views: 0
        }
      }
    },
    computed: {
      username() {
        return this.$store.state.user.username
      },
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {
      addKeep() {
        this.$store.dispatch('addKeep', this.newKeep)
        document.input-form.reset();
      }
    },
    components: {
      ListKeeps
    }
  };
</script>

<style>

</style>