<template>
    <div class="login">
        <!-- <form v-if="loginForm" @submit.prevent="loginUser">
            <input class="m-3" type="email" v-model="creds.email" placeholder="Email" required>
            <input class="m-3" type="password" v-model="creds.password" placeholder="Password" required>
            <button class="btn btn-light m-3 shadow" type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input class="m-3" type="text" v-model="newUser.username" placeholder="Name" required>
            <input class="m-3" type="email" v-model="newUser.email" placeholder="Email" required>
            <input class="m-3" type="password" v-model="newUser.password" placeholder="Password" required>
            <button class="btn btn-light m-1 shadow" type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">Click here to sign up for an account.</p>
            <p v-else>Already have an account? Click here to login.</p>
        </div> -->
        <keep></keep>
    </div>
</template>

<script>
    import Keep from "@/components/Keep.vue"
    import LoginModal from "@/components/LoginModal.vue"
    export default {
        name: "login",
        mounted() {
            // Checks for valid session
            this.$store.dispatch("authenticate");
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
                this.$store.dispatch("login", this.creds);
            }
        },
        components: {
            Keep,
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
</style>