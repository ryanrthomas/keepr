<template>
  <div class="home text-center container-fluid">
    <h1 class="pt-4">Welcome, {{username}}.</h1>
    <h4 class="pb-3">You can post keeps and manage your vaults here.</h4>
    <div class="row d-flex justify-content-center">
      <form v-if="!inputForm" name="keep-form" class="form-group col-12 col-md-5 text-center" @submit.prevent="addKeep">
        <input class="form-control m-2 shadow" type="text" v-model="newKeep.name" placeholder="Title" required><br>
        <input class="form-control m-2 shadow" type="text" v-model="newKeep.description" placeholder="Description"><br>
        <input class="form-control m-2 shadow" type="text" v-model="newKeep.img" placeholder="Image URL"><br>
        <button type="submit" class="btn btn-success mb-3 shadow">Post Keep</button>
      </form>
      <form v-else name="vault-form" class="form-group col-12 col-md-5 text-center" @submit.prevent="addVault">
        <input class="form-control m-2 shadow" type="text" v-model="newVault.name" placeholder="Name" required><br>
        <input class="form-control m-2 shadow" type="text" v-model="newVault.description" placeholder="Description"><br>
        <button type="submit" class="btn btn-success mb-3 shadow">Create Vault</button>
      </form>
    </div>
    <div class="action" @click="inputForm = !inputForm">
      <h5 v-if="!inputForm">Create a vault instead...</h5>
      <h5 v-else>Post a keep instead...</h5>
    </div>
    <div v-if="!inputForm">
      <h3 class="text-left m-2 pb-2">My Keeps ({{myKeeps.length}})</h3>
      <div v-if="myKeeps.length">
        <my-keeps></my-keeps>
      </div>
      <div v-else>
        <h3 class="not-created">You have not created any keeps.</h3>
      </div>
      <h3 class="text-left m-2 pt-3 pb-2">Public Keeps ({{keeps.length}})</h3>
      <list-keeps></list-keeps>
    </div>
    <div v-else>
      <h3 class="text-left m-2 pb-2">My Vaults ({{vaults.length}})</h3>
      <div v-if="vaults.length">
        <list-vaults></list-vaults>
      </div>
      <div v-else>
        <h3 class="not-created">You have not created any vaults.</h3>
      </div>
    </div>
  </div>
</template>

<script>
  import ListKeeps from "@/components/ListKeeps.vue"
  import MyKeeps from "@/components/MyKeeps.vue"
  import ListVaults from "@/components/ListVaults.vue"
  export default {
    name: "home",
    mounted() {
      // Blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getKeeps')
      this.$store.dispatch('getVaults')
      this.$store.dispatch('getVaultKeeps(vault)')
    },
    data() {
      return {
        inputForm: false,
        newKeep: {
          name: "",
          description: "",
          img: "",
          isPrivate: true,
          userId: "",
          keeps: 0,
          shares: 0,
          views: 0
        },
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {
      username() {
        return this.$store.state.user.username
      },
      userId() {
        return this.$store.state.user.id
      },
      myKeeps() {
        return this.$store.state.keeps
      },
      keeps() {
        return this.$store.state.keeps
      },
      vaults() {
        return this.$store.state.vaults
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {
      addKeep() {
        let newKeep = this.newKeep
        newKeep.userId = this.userId
        this.$store.dispatch('addKeep', newKeep)
        this.newKeep = { name: "", description: "", img: "" }
      },
      addVault() {
        this.$store.dispatch('addVault', this.newVault)
        this.newVault = { name: "", description: "" }
      },
      addVaultKeep(){
        this.$store.dispatch('addVaultKeep', this.newVaultKeep)
      }
    },
    components: {
      ListKeeps,
      MyKeeps,
      ListVaults
    }
  };
</script>

<style>
  .action {
    cursor: pointer;
  }

  .home {
    /* background-image: url("https://i0.wp.com/faircastinc.com/wp-content/uploads/2018/06/AdobeStock_100636545-1.jpeg?ssl=1"); */
    color: white;
    text-shadow: 1px 2px 0 black;
  }

  .card {
    margin-top: -5px !important;
    margin-right: -4px !important;
    background-color: rgba(0, 0, 0, 0.5);
    border-color: white;
    border-width: 4px;
  }

  .not-created {
    padding: 20px;
    margin-bottom: 35px;
    background-color: rgba(0, 0, 0, 0.5);
    border-color: white;
    border-width: 4px;
    border-style: solid;
  }
</style>