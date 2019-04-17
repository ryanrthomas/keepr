<template>
    <div class="vault-keeps">
        <ul class="text-left pl-4 m-0" v-for="keep in keeps">
            <li class="p-0">{{keep.name}}</li><br>
        </ul>
    </div>
</template>


<script>
    export default {
        name: "vault-keeps",
        props: [],
        mounted() {
            this.$store.dispatch('getVaults')
        },
        data() {
            return {}
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            vaults() {
                return this.$store.state.vaults
            },
            isLoggedIn() {
                return this.$store.state.user.active;
            }
        },
        methods: {
            addKeepView() {
                // this.$store.dispatch()
            }
        },
        components: {}
    }
</script>


<style>
    .card {
        border-style: solid;
        border-width: thin;
        border-color: black;
        border-radius: 0%;
    }

    .keep-menu {
        padding: 5px;
        color: white;
        text-shadow: none;
        background-color: #bd2130;
    }

    .share-menu {
        padding: 5px;
        color: black;
        text-shadow: none;
        background-color: gold;
    }

    .modal {
        text-shadow: none;
    }

    .modal-image {
        width: 300px;
        height: auto;
    }
    li{
        cursor: pointer;
    }
</style>