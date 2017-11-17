<<template>
<div class="sign_up">
            <h1>Регистрация</h1>
            <form action="/signup" method = "POST">
                <div class="top-row">
                    <div class="field_wrap">
                        <input name = "name" v-bind:class="{invalid : !isNameValid}" class="input" required autocomplete="off" placeholder="Имя пользователя" type="text" v-on:focus="nameOnFocus=true" v-model="name"/>
                        <div class="error" v-show="!isNameValid">
                            <span>Поле не должно быть пустым</span>
                        </div>
                    </div>

                    <div class="field_wrap">
                        <input name = "password" v-bind:class="{invalid : !isPasswordValid}" class="input"  required autocomplete="off" type="password" placeholder="Пароль" v-model="password">
                        <div class="error" v-show="password && !isPasswordValid">
                            <span>Пароль должен содержать 8-16 символов</span>
                        </div>
                    </div>
                </div>
                <div class="field_wrap">
                    <input name="phoneNumber" class="input" v-bind:class="{invalid : !isPhoneValid}" required autocomplete="off" type="text" placeholder="Телефон" v-model="phone">
                    <div class="error" v-show="phone && !isPhoneValid">
                        <span>Неправильный номер телефона</span>
                    </div>
                </div>

                <div class="field_wrap">
                    <input name="email" class="input" v-bind:class="{invalid : !isEmailValid}" type="email" placeholder="e-mail" required autocomplete="off" v-model="email"/>
                    <div class = "error" v-show="email && !isEmailValid">
                        <span>Неправильный email</span>
                    </div>
                </div>

                <button :disabled="!isEmailValid || !isPhoneValid || !isPasswordValid">Зарегестрироваться</button>
            </form>
</div>
</template>

<<script>
import {nameValidate, emailValidate, phoneValidate, passwordValidate} from './validate.js'

export default {
  name: 'sign-up',
  data () {
    return {
      name : '',
      nameOnFocus : false,
      email : '',
      phone : '',
      password : ''
    }
  },
  computed: {
    isNameValid(){
          return !this.nameOnFocus || nameValidate(this.name);
        },
    isEmailValid() {
          return emailValidate(this.email);
      },
    isPhoneValid(){
          return phoneValidate(this.phone);
      },
    isPasswordValid(){
          return passwordValidate(this.password);
      }
    }
}
</script>
