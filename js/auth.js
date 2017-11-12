new Vue({
    el: '#app',
    data: {
        name : '',
        nameOnFocus:false,
        email: '',
        phone:'',
        password:'',
        showSignUp : true,
        showSignIn: false
    },
    computed: {
        isNameValid(){
          return !this.nameOnFocus || this.name.length>0;
        },
        isEmailValid() {

            return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(this.email);
        },
        isPhoneValid(){
            return /^((\+7|8)[ \-]?){1}((\(\d{3}\))|(\d{3})){1}([ \-])?(\d{3}[\- ]?\d{2}[\- ]?\d{2})$/.test(this.phone);
        },
        isPasswordValid(){
            return (this.password.length>=8 && this.password.length<=16);
        }
    },
    methods:{
        showForm(num){
            console.log(num);
            switch(num){
                case 1:
                    this.showSignUp = true;
                    this.showSignIn = false;
                    break;
                case 2:
                    this.showSignUp = false;
                    this.showSignIn = true;
                    break;
            }
        }
    }
});