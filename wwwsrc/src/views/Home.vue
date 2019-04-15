<template>
  <div class="home">
    <h1 class="mt-2">Welcome, {{username}}.</h1>
    <h4>You can post keeps and manage your vaults here.</h4>
    <form @submit.prevent="addKeep">
      <input class="m-2" type="text" v-model="keeps.name" placeholder="Title" required><br>
      <input class="m-2" type="text" v-model="keeps.Description" placeholder="Description"><br>
      <input class="m-2" type="text" v-model="keeps.Image" placeholder="Image URL" required><br>
      <button type="submit" class="btn btn-success">Post Keep</button>
    </form>
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
        return this.$store.state.addKeep

      }
    },
    components: {
      ListKeeps
    }
  };
</script>

<style>

</style>