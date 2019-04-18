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
                        <p class="card-text"><b>K</b>{{keep.keeps}} <i class="fas fa-share"></i> {{keep.shares}}&nbsp<i
                                class="fas fa-eye"></i> {{keep.views}}
                        </p>
                        <button class="btn btn-danger m-1 shadow dropdown-toggle" @click="addKeepCount(keep)"
                            data-toggle="dropdown" id="dropdownKeepButton" aria-haspopup="true" aria-expanded="false"
                            title="Keep">
                            <b>K</b></button>
                        <div class="dropdown-menu keep-menu shadow" aria-labelledby="dropdownKeepButton">
                            <p class="menu-option m-0 pl-2" @click="addKeepCount(keep)" v-for="vault in vaults">{{vault.name}}</p>
                        </div>
                        <button class="btn btn-warning m-1 shadow dropdown-toggle" data-toggle="dropdown" id="dropdownShareButton" aria-haspopup="true" aria-expanded="false"
                            title="Share"><i class="fas fa-share"></i></button>
                        <div class="dropdown-menu share-menu shadow" aria-labelledby="dropdownShareButton">
                            <p @click="addKeepShare(keep)">Facebook</p>
                            <p @click="addKeepShare(keep)">Twitter</p>
                            <p @click="addKeepShare(keep)">Instagram</p>
                        </div>
                        <button class="btn btn-primary m-1 shadow" @click="addKeepView(keep)" data-toggle="modal"
                            :data-target="'#keep-details-'+keep.id" title="View"><i class="fas fa-eye"></i></button>
                        <button class="btn btn-dark m-1 shadow" @click="deleteKeep(keep)" title="Delete keep"><i
                                class="fas fa-trash"></i></button>
                    </div>
                </div>
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
                            <div class="modal-body">
                                <img class="modal-image shadow"
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
        props: ['keepId'],
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
            addKeepCount(keep) {
                keep.keeps++;
                this.$store.dispatch('addKeepCount', keep)
            },
            addKeepShare(keep) {
                keep.shares++;
                this.$store.dispatch('addKeepShare', keep)
            },
            addKeepView(keep) {
                keep.views++;
                this.$store.dispatch('addKeepView', keep)
            },
            deleteKeep(keep) {
                if (confirm("Are you sure you want to delete this keep?")) {
                    this.$store.dispatch("deleteKeep", keep)
                }
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
        border-radius: 10px;
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
    .menu-option{
        cursor: pointer;
    }
</style>