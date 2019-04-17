<template>
    <div class="vault-keeps">
        <div class="row" v-for="keep in keeps">
            <div class="col-12">
                <img class="vault-image m-1 shadow" :src="keep.img||'https://www.elegantthemes.com/blog/wp-content/uploads/2017/08/featuredimage.jpg'" data-toggle="modal"
                    :data-target="'#keep-details-'+keep.id">
                <!-- Modal -->
                <div class="modal fade" :id="'keep-details-'+keep.id" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">{{keep.name}}</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body text-center">
                                <img class="modal-image shadow"
                                    :src="keep.img ||'https://www.elegantthemes.com/blog/wp-content/uploads/2017/08/featuredimage.jpg'"">
                                <p class=" pt-4">{{keep.description}}</p>
                                <p class="card-text"><b>K</b> 0&nbsp<i class="fas fa-share"></i> {{keep.shares}}&nbsp<i
                                        class="fas fa-eye"></i> {{keep.views}}</p>
                                <p class="m-0">
                                    <button class="btn btn-dark m-1 shadow" @click="removeFromVault">Remove From
                                        Vault</button>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
            },
            removeFromVault() {
                confirm("Are you sure you want to remove this keep from the vault?")
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

    .vault-image {
        height: auto;
        width: 100px;
        cursor: pointer;
        border-color: white;
        border-width: 2px;
        border-style:solid;
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
        border-radius: 10px;
    }
</style>