<template>
    <div>
        <v-row class="mt-3">
            <h3 class="ml-2">Dashboard</h3>
        </v-row>
        <v-row>
            <v-col md="4">
                <v-card
                    class="mx-auto"
                    max-width="344"
                    style="padding: 20px;"
                >
                    <v-row>
                        <v-col md="2">
                        <v-avatar color="orange">
                            <v-icon icon="mdi-currency-usd"></v-icon>
                        </v-avatar>
                        </v-col>
                        <v-col>
                        <p style="font-size: 12px; color: #00ff80;">Total Sales</p>
                        <p>$ {{ totalCal() }} </p>
                        </v-col>
                    </v-row>
                </v-card>
            </v-col>
            <v-col md="4">
                <v-card
                    class="mx-auto"
                    max-width="344"
                    style="padding: 20px;"
                >
                    <v-row>
                        <v-col md="2">
                        <v-avatar color="red">
                            <v-icon icon="mdi-cart-outline"></v-icon>
                        </v-avatar>
                        </v-col>
                        <v-col>
                        <p style="font-size: 12px; color: #00ff80;">Total Orders</p>
                        <p>{{ listOrder.length }}</p>
                        </v-col>
                    </v-row>
                </v-card>
            </v-col>
            <v-col md="4">
                <v-card
                    class="mx-auto"
                    max-width="344"
                    style="padding: 20px;"
                >
                    <v-row>
                        <v-col md="2">
                        <v-avatar color="blue-darken-2">
                            <v-icon icon="mdi-basket"></v-icon>
                        </v-avatar>
                        </v-col>
                        <v-col>
                        <p style="font-size: 12px; color: #00ff80;">Total Products</p>
                        <p>{{ listJewelry.length }}</p>
                        </v-col>
                    </v-row>
                </v-card>
            </v-col>
        </v-row>
        <v-row>
            <v-col md="8">
                <v-card
                    title="Latest Orders"
                >
                    <v-table>
                        <thead>
                        <tr>
                            <th class="text-left"></th>
                            <th class="text-left" style="width: 200px;">
                                Name
                            </th>
                            <th class="text-center">
                                Email
                            </th>
                            <th class="text-left">
                                Total
                            </th>
                            <th class="text-center">
                                Date
                            </th>
                            <th class="text-center">
                                Status
                            </th>
                            <th class="text-center">
                                Action
                            </th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr
                            v-for="item in lastestOrder" :key="item"
                        >
                            <td></td>
                            <td>{{ item.userName }}</td>
                            <td>{{item.userEmail}}</td>
                            <td>$ {{ item.orderTotal }}</td>
                            <td>{{ item.orderDate.slice(0,10) }}</td>
                            <td class="text-center">
                                <v-chip
                                    class="ma-2"
                                    :color="item.orderStatus === 0 ? 'pink' : 'blue'"
                                    label
                                    >
                                    <v-icon start :icon="item.orderStatus === 0 ? 'mdi-truck' : 'mdi-check-circle'"></v-icon>
                                    {{ item.orderStatus == 0 ? 'Đang giao hàng' : 'Đã hoàn thành' }}
                                </v-chip>
                            </td>
                            <td class="text-center">
                                <v-btn color="blue" class="mr-3" icon size="x-small" @click="dialogDetail = true, currentItem = item">
                                    <v-icon>mdi-eye</v-icon>
                                </v-btn>
                            </td>
                        </tr>
                        </tbody>
                    </v-table>
                </v-card>
            </v-col>

            <v-col>
                <v-card title="New Customers">
                    <v-table>
                        <thead>
                        <tr>
                            <th class="text-left">
                            ID
                            </th>
                            <th class="text-left">
                                Ten khach hang
                            </th>
                            <th class="text-left">
                                Email
                            </th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr
                            v-for="item in newCustomer"
                            :key="item.userId"
                        >
                            <td>{{ item.userId }}</td>
                            <td>{{ item.userName }}</td>
                            <td>{{ item.userEmail }}</td>
                        </tr>
                        </tbody>
                    </v-table>
                </v-card>
            </v-col>
        </v-row>
        
        <admin-detail-order
            :dialogDetail="dialogDetail"
            @close="dialogDetail = false"
            :currentItem = "currentItem"
        />
    </div>
</template>

<script>
  import { mapGetters, mapActions } from 'vuex'
  import AdminDetailOrder from './AdminDetailOrder.vue';
  export default {
    components: {AdminDetailOrder },
    data () {
      return {
        dialogDetail: false,
        currentItem: '',
      }
    },
    computed:{
        ...mapGetters(['listJewelry', 'listOrder', 'listCustomer']),
        lastestOrder(){
            const length = this.listOrder.length;
      
            return this.listOrder.reverse().slice(Math.max(length - 5, 0));
        },
        newCustomer(){
            const length = this.listCustomer.length;
      
            return this.listCustomer.reverse().slice(Math.max(length - 5, 0));
        }
    },
    created(){
        this.getOrders();
        this.getCustomers(); 
        this.getJewelries();
        
    },
    methods:{
        ...mapActions(['getOrders', 'getCustomers', 'getJewelries']),

        totalCal(){
            var total = 0;
            for(let i = 0; i < this.listOrder.length; i++)
            {
                total = total + this.listOrder[i].orderTotal;
            }
            return total;
        }
    }
  }
</script>

<style>

</style>