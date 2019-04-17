<template>
    <div class="login text-center container-fluid">
        <!-- <div class="row d-flex justify-content-center">
            <form class="form-group col-12 col-md-5 text-center" v-if="loginForm" @submit.prevent="loginUser">
                <input class="form-control m-3" type="email" v-model="creds.email" placeholder="Email" required>
                <input class="form-control m-3" type="password" v-model="creds.password" placeholder="Password"
                    required>
                <label class="form-check-label"><input type="checkbox" class="form-check-input">Remember me</label>
                <button class="btn btn-light m-3 shadow" type="submit">Log In</button>
            </form>
            <form class="form-group col-12 col-md-5 text-center" v-else @submit.prevent="register">
                <input class="form-control m-3" type="text" v-model="newUser.username" placeholder="Name" required>
                <input class="form-control m-3" type="email" v-model="newUser.email" placeholder="Email" required>
                <input class="form-control m-3" type="password" v-model="newUser.password" placeholder="Password"
                    required>
                <button class="btn btn-light m-1 shadow" type="submit">Create Account</button>
            </form>
        </div>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">Click here to sign up for an account.</p>
            <p v-else>Already have an account? Click here to login.</p>
        </div> -->
        <list-keeps></list-keeps>
    </div>
</template>

<script>
    import ListKeeps from "@/components/ListKeeps.vue"
    import LoginModal from "@/components/LoginModal.vue"
    export default {
        name: "login",
        mounted() {
            // Checks for valid session
            this.$store.dispatch("authenticate");
            this.$store.dispatch("getKeeps");
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                debugger
                this.$store.dispatch("login", this.creds);
            }
        },
        components: {
            ListKeeps,
            LoginModal
        }
    };
</script>

<style>
    .navbar {
        background-color: black;
        color: white;
        height: auto;
    }

    .login {
        /* background-image: url("https://i0.wp.com/faircastinc.com/wp-content/uploads/2018/06/AdobeStock_100636545-1.jpeg?ssl=1"); */
        color: white;
        text-shadow: 1px 2px 0 black;
    }

    .card {
        margin-top: -5px;
        margin-right: -5px;
        background-color: rgba(0, 0, 0, 0.5);
        border-color: white;
        border-width: 4px;
    }
</style>