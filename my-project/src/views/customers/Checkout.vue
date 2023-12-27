<template>
  <div>
    <v-row>
        <v-col md="6">
          <v-text-field
            v-model="this.user.user.userName"
            label="Họ tên"
            :rules="[rules.required]"
          ></v-text-field>

          <v-text-field
            v-model="this.order.Address"
            label="Địa chỉ"
            :rules="[rules.required]"
          ></v-text-field>

          <v-text-field
            v-model="this.order.Phone"
            label="Số điện thoại"
            :rules="[rules.required]"
            maxlength="10"
          ></v-text-field>

          <v-text-field
            v-model="this.user.user.userEmail"
            :rules="[rules.required, rules.email]"
            label="E-mail"
          ></v-text-field>
        </v-col>

        <v-col>
            <v-card>
                <v-card-item>
                    <v-card-title style="font-weight: bold; margin-bottom: 10px;">Đơn hàng của bạn</v-card-title>

                    <v-table>
                        <tbody>
                            <tr style="color: #7d7d7d"
                                v-for="i in cart"
                                :key="i.itemCart.jewelryId"
                            >
                                <td width="50" style="padding: 5px;">
                                    <v-img
                                        :src="i.itemCart.jewelryImages[0]"
                                        height="50"
                                        width="50"
                                        cover
                                    ></v-img>
                                </td>
                                <td>{{ i.itemCart.jewelryName }} <br> <span>x {{ i.quantity }}</span></td>
                                <td style="text-align: right;">$ {{ i.itemCart.jewelryPrice * i.quantity }}</td>
                            </tr>
                        </tbody>
                    </v-table>

                    <v-card-actions>
                        <v-list-item class="w-100">
                        <template v-slot:prepend>
                            <h3>Tổng tiền</h3>
                        </template>


                        <template v-slot:append>
                            <div>
                            <span>$ {{total - (total * 0.05) }}</span>
                            </div>
                        </template>

                        </v-list-item>

                    </v-card-actions>
                    
                    <v-card-text>
                        <v-btn
                        variant="text"
                        color="deep-purple-accent-4"
                        class="w-100"
                        to="/"
                        @click="this.add"
                        >
                        Thanh toán
                        </v-btn>
                    </v-card-text>
                </v-card-item>

            </v-card>
        </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapActions, mapGetters, mapMutations, mapState } from 'vuex';
export default {
    data(){
        return{
          order:{
            orderDate: '',
            orderTotal: '',
            orderStatus: '',
            Address: '',
            Phone: '', 
            userId:'',
             
          },
            rules: {
                required: value => !!value || 'Required.',
                email: value => {
                const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
                return pattern.test(value) || 'Invalid e-mail.'
                },
            }
        }
    },
    computed: {
        ...mapState(['cart', 'user']),
        total(){
        let total = 0;
        if(this.cart.length > 0)
        {
          for(let i = 0; i < this.cart.length; i++ )
          {
            total += this.cart[i].itemCart.jewelryPrice * this.cart[i].quantity;
          }
        }
        return total;
      },
    },
    methods:{
      ...mapActions(['addOrder']),
      add(){
        this.order.orderDate = new Date(),
        this.order.orderTotal = this.total - (this.total * 0.05),
        this.order.orderStatus = 0,
        this.order.userId = this.user.user.userId;

        
        this.addOrder(this.order);
      }
    }
}
</script>

<style>

</style>