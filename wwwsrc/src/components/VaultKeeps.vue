<template>
    <div class="vault-keeps">
        <ul class="text-left pl-4 m-0" v-for="keep in keeps">
            <li data-toggle="modal" data-target="#keep-details" class="p-0">{{keep.name}}</li>
            <!-- Modal -->
            <div class="modal fade" id="keep-details" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">{{keep.name}}</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <!-- Keep image goes here -->
                            <img class="modal-image"
                                :src="keep.img ||'https://www.elegantthemes.com/blog/wp-content/uploads/2017/08/featuredimage.jpg'"">
                                <p class=" text-center pt-4">{{keep.description}}</p>
                            <p class="card-text text-center"><b>K</b> 0&nbsp<i class="fas fa-share"></i> (Share
                                count)&nbsp<i class="fas fa-eye"></i> {{keep.views}}</p>
                            <p class="m-0 text-center">
                                <button class="btn btn-dark m-1 shadow">Remove From
                                    Vault</button>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
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

    li {
        cursor: pointer;
    }
</style>