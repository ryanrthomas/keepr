<template>
    <div class="my-keeps container-fluid">
        <div class="row">
            <div class="col p-0 col-12 col-sm-4 col-md-3 col-xl-2" v-for="keep in keeps">
                <div class="card" style="width: auto; ">
                    <img class="card-img-top"
                        :src="keep.img ||'https://www.elegantthemes.com/blog/wp-content/uploads/2017/08/featuredimage.jpg'"
                        alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">{{keep.name}}</h5>
                        <p class="card-text"><b>K</b> 0&nbsp<i class="fas fa-share"></i> {{keep.shares}}&nbsp<i
                                class="fas fa-eye"></i> {{keep.views}}
                        </p>
                        <button class="btn btn-danger m-1 shadow dropdown-toggle" data-toggle="dropdown"
                            id="dropdownKeepButton" aria-haspopup="true" aria-expanded="false" title="Keep">
                            <b>K</b></button>
                        <div class="dropdown-menu keep-menu shadow" aria-labelledby="dropdownKeepButton">
                            <p class="m-0 pl-2" v-for="vault in vaults">{{vault.name}}</p>
                        </div>
                        <button class="btn btn-warning m-1 shadow dropdown-toggle" data-toggle="dropdown"
                            id="dropdownShareButton" aria-haspopup="true" aria-expanded="false" title="Share"><i
                                class="fas fa-share"></i></button>
                        <div class="dropdown-menu share-menu shadow" aria-labelledby="dropdownShareButton">
                            <p>Facebook</p>
                            <p>Twitter</p>
                            <p>Instagram</p>
                        </div>
                        <button class="btn btn-primary m-1 shadow" data-toggle="modal" data-target="#keep-details"
                            title="View"><i class="fas fa-eye"></i></button>
                        <!-- <p class="m-0 pt-4 text-right"><i class="delete-vault fas fa-trash" @click=""
                                title="Delete keep"></i></p> -->
                        <button class="btn btn-dark m-1 shadow" @click="deleteKeep" title="Delete keep"><i
                                class="fas fa-trash"></i></button>
                    </div>
                </div>
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
                                <img class="modal-image"
                                    :src="keep.img ||'https://www.elegantthemes.com/blog/wp-content/uploads/2017/08/featuredimage.jpg'">
                                <p class="pt-4">{{keep.description}}</p>
                                <p class="card-text text-center"><b>K</b> 0&nbsp<i class="fas fa-share"></i>
                                    {{keep.shares}}&nbsp<i class="fas fa-eye"></i> {{keep.views}}
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
    import ListVaults from "@/components/ListVaults.vue"
    export default {
        name: "my-keeps",
        props: ['keepData'],
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
            addKeepView(keep) { },
            deleteKeep(keep) {
                this.$store.dispatch("deleteKeep", this.keepData)
            }
        },
        components: {
            ListVaults
        }
    }
</script>


<style>
    .card {
        border-style: solid;
        border-width: thin;
        border-color: black;
        border-radius: 0%;
    }

    /* .card-img-top{
            height: 200px;
            background-position: center;
        } */

    .modal-image {
        width: 300px;
        height: auto;
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
</style>