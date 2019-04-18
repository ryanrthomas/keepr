<template>
    <div class="navbar">
        <h1 class="navbar-title">KEEPR</h1>
        <div v-if="isLoggedIn">
            <button @click="logoutUser" type="button" class="btn m-2 btn-warning">Sign Out</button>
        </div>
        <div v-else>
            <button type="button" data-toggle="modal" data-target="#loginModal" class="btn m-2 btn-outline-primary">Sign
                In</button>
            <button type="button" data-toggle="modal" data-target="#registerModal"
                class="btn m-2 btn-primary">Register</button>
        </div>
        <!-- MODAL -->
        <div id="loginModal" class="modal fade" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Sign In</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form class="form-group" @submit.prevent="loginUser">
                            <input class="m-1 form-control" type="email" v-model="creds.email" placeholder="Email" required>
                            <input class="m-1 form-control" type="password" v-model="creds.password" placeholder="Password" required><br>
                            <button class="btn btn-primary m-1" type="submit">Submit</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div id="registerModal" class="modal fade" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Create an account</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form class="form-group" @submit.prevent="register">
                            <input class="m-1 form-control" type="text" v-model="newUser.username" placeholder="Name" required>
                            <input class="m-1 form-control" type="email" v-model="newUser.email" placeholder="Email" required>
                            <input class="m-1 form-control" type="password" v-model="newUser.password" placeholder="Password" required><br>
                            <button class="btn btn-primary m-1" type="submit">Create Account</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
    export default {
        name: "navbar",
        props: [],
        mounted() {
            // Checks for valid session
            this.$store.dispatch("authenticate");
        },
        data() {
            return {
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            }
        },
        computed: {
            isLoggedIn() {
                return this.$store.state.user.active;
            }
        
        },
        methods: {
            // showLoginModal() {
            //     $('#loginModal').modal()
            // },
            // showRegisterModal() {
            //     $('#registerModal').modal()
            // },
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                $('#loginModal').modal('hide')
                this.$store.dispatch("login", this.creds);
            }, 
            logoutUser() {
                this.$store.dispatch("logout", this.user)
            }
        },
        components: {

        }
    }
</script>


<style>
    .modal-content {
        color: black;
    }

    .navbar-title {
        font-family: 'Oswald', sans-serif;
        font-size: 52px;
    }
</style>