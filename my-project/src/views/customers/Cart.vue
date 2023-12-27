<template>
  <div>
    <v-row>
      <v-col md="8">
        <h3 style="text-align: center;" v-if="cart.length == 0">Chưa có sản phẩm nào trong giỏ hàng</h3>
        <v-table>
          <tbody>
            <tr
              v-for="i in cart"
              :key="i.itemCart.jewelryId"
            >
              <td>
                 <v-card class="my-2" elevation="2" rounded max-width="150px">
                  <v-img
                      :src="i.itemCart.jewelryImages[0]"
                      height="100"
                      width="200"
                      cover
                  ></v-img>
                </v-card>
              </td>
              <td>{{ i.itemCart.jewelryName }}</td>
              <td>
                <v-btn @click="this.decrementCartQuantity(i)" small variant="text">-</v-btn>
                <span>{{ i.quantity }}</span>
                <v-btn @click="this.incrementCartQuantity(i)" small variant="text">+</v-btn>
              </td>
              <td>{{ i.itemCart.jewelryPrice * i.quantity }}</td>
              <td>
                <v-btn
                    class="ma-2"
                    variant="text"
                    icon="mdi-delete"
                    color="blue-lighten-2"
                    @click="DeleteItemCart(i.itemCart.jewelryId)"
                ></v-btn>
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-col>
      <v-col>
        <v-card
          class="mx-auto"
        >
          <v-card-actions>
            <v-list-item class="w-100">
              <template v-slot:prepend>
                <h3>Tổng tiền sản phẩm</h3>
              </template>


              <template v-slot:append>
                <div>
                  <span>{{ total }}</span>
                </div>
              </template>

            </v-list-item>

          </v-card-actions>
          <v-card-text>
            <v-card
              disabled
            >
              <v-card-item>
                <v-list-item class="w-100">
                <template v-slot:prepend>
                  <h3>Tiền ship</h3>
                </template>


                <template v-slot:append>
                  <div>
                    <span>Free</span>
                  </div>
                </template>
                
              </v-list-item>

              <v-list-item class="w-100">
                <template v-slot:prepend>
                  <h3>Khuyễn mãi</h3>
                </template>


                <template v-slot:append>
                  <div class="justify-self-end">
                    <span>5 %</span>
                  </div>
                </template>
                
              </v-list-item>

              </v-card-item>
            </v-card>
          </v-card-text>

          <v-card-actions>
            <v-list-item class="w-100">
              <template v-slot:prepend>
                <h3>Tổng tiền</h3>
              </template>


              <template v-slot:append>
                <div>
                  <span>$ {{total - ( total * 0.05 ) }}</span>
                </div>
              </template>

            </v-list-item>

          </v-card-actions>
          
          <v-card-text>
            <v-btn
              variant="text"
              color="deep-purple-accent-4"
              class="w-100"
              to="/customers/checkout"
            >
              Thanh toán
            </v-btn>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

</div>
</template>
<script>
import { mapActions, mapGetters, mapMutations, mapState } from 'vuex';
  export default {
    data () {
      return {
      }
    },
    computed: {
      ...mapState(['cart']),
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
    
    methods: {
      ...mapMutations(['incrementCartQuantity', 'decrementCartQuantity']),
      ...mapActions(['DeleteItemCart']),
    }
  }
</script>

<style>

.d-flex {
display: flex;
}

.align-center {
align-items: center;
}

.mx-2 {
margin-left: 0.5rem;
margin-right: 0.5rem;
}
</style>