<template>
    <div class="list-keeps container-fluid">
        <div class="row">
            <div class="p-0 col-12 col-sm-6 col-md-4 col-lg-3" v-for="keep in keeps">
                <div class="card" style="width: auto;">
                    <img class="card-img-top" :src="keep.img" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">{{keep.name}}</h5>
                        <p class="card-description">{{keep.description}}</p>
                        <p class="card-text"><b>K</b> 0&nbsp<i class="fas fa-share"></i> {{keep.shares}}&nbsp<i
                                class="fas fa-eye"></i> {{keep.views}}
                        </p>
                        <button class="btn btn-danger m-1 shadow dropdown-toggle" data-toggle="dropdown"
                            id="dropdownMenuButton" aria-haspopup="true" aria-expanded="false"
                            title="Keep"><b>K</b></button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <p v-for="vault in vaults">{{vault.name}}</p>
                        </div>
                        <button class="btn btn-warning m-1 shadow" title="Share"><i class="fas fa-share"></i></button>
                        <button class="btn btn-primary m-1 shadow" data-toggle="modal" data-target="#keep-details"
                            title="View"><i class="fas fa-eye"></i></button>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal" id="keep-detais" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Modal title</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Modal body text goes here.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
    import ListVaults from "@/components/ListVaults.vue"
    export default {
        name: "list-keeps",
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
            }
        },
        methods: {},
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

    .dropdown-menu {
        padding: 5px;
        color: white;
        text-shadow: none;
        background-color: #bd2130;
    }
</style>