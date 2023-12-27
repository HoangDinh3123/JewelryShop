<template>
    <v-container>
        <v-row align="center" justify="center" >
            <v-col cols="12" sm="10">
              <v-card class="elevation-6 mt-10"  >
               <v-window v-model="step">
                  <v-window-item :value="1">
                    <v-row>
                      <v-col cols="12" md="6">
                        <v-card-text class="mt-12">
                          <h4
                            class="text-center"
                          >Đăng nhập</h4>
                          <h6
                            class="text-center  grey--text "
                          >Đăng nhập với tài khoản của bạn</h6>
                          <v-row align="center" justify="center">
                            
                                <v-col cols="12" sm="8">
                                <v-form>
                                    <v-text-field
                                        v-model="user.userEmail"
                                        label="Email"
                                        outlined
                                        dense
                                        color="blue"
                                        autocomplete="false"
                                        class="mt-16"
                                    />
                                    <v-text-field
                                        v-model="user.userPassword"
                                        label="Password"
                                        outlined
                                        dense
                                        color="blue"
                                        autocomplete="false"
                                        type="password"
                                    
                                    />
                                </v-form>
                                    <v-btn @click="this.login(user)" color="blue" dark block tile>Đăng nhập</v-btn>
                                </v-col>
                          </v-row>  
                        </v-card-text>
                      </v-col>
                      <v-col cols="12" md="6" class="blue rounded-bl-xl" >
                      <div style="  text-align: center; padding: 180px 0;">
                        <v-card-text class="white--text" >
                          <h3 class="text-center ">Chưa có tài khoản?</h3>
                        </v-card-text>
                        <div class="text-center">
                          <v-btn tile outlined dark @click="step++">Đăng ký</v-btn>
                        </div>
                        </div>
                      </v-col>
                    </v-row>
                  </v-window-item>


                  <!-- Sign up -->

                  <v-window-item :value="2">
                    <v-row >
                      <v-col cols="12" md="6" class="blue rounded-br-xl">
                       <div style="  text-align: center; padding: 180px 0;">
                        <v-card-text class="white--text" >
                          <h3 class="text-center ">Alredy Signed up?</h3>
                          <h6
                            class="text-center"
                          >Log in to your account so you can continue building and<br>  editing your onboarding flows</h6>
                        </v-card-text>
                        <div class="text-center">
                          <v-btn tile outlined dark @click="step--">Log in</v-btn>
                        </div>
                        </div>
                      </v-col>
  
                      <v-col cols="12" md="6">
                        <v-card-text class="mt-12">
                          <h4
                            class="text-center"
                          >Sign Up for an Account</h4>
                          <h6
                            class="text-center  grey--text "
                          >Let's get you all set up so you can start creatin your <br>
                          first onboarding experiance</h6>
                          <v-row align="center" justify="center">
                            <v-col cols="12" sm="8">
                             <v-row>
                             <v-col cols="12">
                              <v-text-field
                                v-model="user.userName"
                                label="First Name"
                                outlined
                                dense
                                color="blue"
                                autocomplete="false"
                                class="mt-4"
                              />
                             </v-col>
                             </v-row>
                            <v-text-field
                              v-model="user.userEmail"
                              label="Email"
                              outlined
                              dense
                              color="blue"
                              autocomplete="false"
                            />
                            <v-text-field
                                v-model="user.userPassword"
                                label="Password"
                                outlined
                                dense
                                color="blue"
                                autocomplete="false"
                              type="password"
                            />

                            <v-text-field
                                v-model="user.userPhone"
                                label="Số điện thoại"
                                outlined
                                dense
                                color="blue"
                                autocomplete="false"
                            />
                            <v-btn @click="this.showAlert()" color="blue" dark block tile>Sign up</v-btn>
                       
                            </v-col>
                          </v-row>  
                        </v-card-text>
                      </v-col>
                    </v-row>
                  </v-window-item>
                </v-window>
              </v-card>
            </v-col>
        </v-row>
    </v-container>
  </template>
  
  <script>
    import { mapActions } from 'vuex';
    export default {
     data: () => ({
      step: 1,
      user: {
            userEmail: '',
            userPassword: '',
            userName:'',
            userPhone: ''
        }
    }),

    methods: {
            ...mapActions(['login', 'signup']),
            showAlert() {
              this.signup(this.user);
              // Use sweetalert2
              this.$swal.fire({
                icon: 'success',
                title: 'Success!!!',
                showConfirmButton: false,
                timer: 1500
              })
          }
        },
      
    }
  </script>


  <style scoped>
  .v-application .rounded-bl-xl {
      border-bottom-left-radius: 300px !important;
  }
  .v-application .rounded-br-xl {
      border-bottom-right-radius: 300px !important;
  }
  </style>