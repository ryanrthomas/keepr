<template>
    <div class="my-keeps container-fluid">
        <div class="row">
            <div class="p-0 col-12 col-sm-6 col-md-4 col-xl-2" v-for="keep in keeps">
                <div class="card" style="width: auto;">
                    <img class="card-img-top"
                        :src="keep.img ||'https://www.elegantthemes.com/blog/wp-content/uploads/2017/08/featuredimage.jpg'"
                        alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">{{keep.name}}</h5>
                        <p class="card-text"><b>K</b> 0&nbsp<i class="fas fa-share"></i> {{keep.shares}}&nbsp<i
                                class="fas fa-eye"></i> {{keep.views}}
                        </p>
                        <button class="btn btn-danger m-1 shadow" title="Keep"><b>K</b></button>
                        <button class="btn btn-warning m-1 shadow" title="Share"><i class="fas fa-share"></i></button>
                        <button class="btn btn-primary m-1 shadow" data-toggle="modal" data-target="#keep-details"
                            title="View"><i class="fas fa-eye"></i></button>
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
                                <!-- Keep image goes here -->
                                <img class="modal-image"
                                    :src="keep.img ||'https://www.elegantthemes.com/blog/wp-content/uploads/2017/08/featuredimage.jpg'">
                                <p class="pt-4">{{keep.description}}</p>
                                <p class="card-text text-right"><b>K</b> 0&nbsp<i class="fas fa-share"></i>
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
    export default {
        name: "my-keeps",
        props: [],
        mounted() { },
        data() {
            return {}
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            isLoggedIn() {
                return this.$store.state.user.active;
            }
        },
        methods: {
            addKeepView() {
                this.$store.dispatch()
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

    /* .card-img-top{
            height: 200px;
            background-position: center;
        } */

    .modal-image {
        width: 300px;
        height: auto;
    }
</style>