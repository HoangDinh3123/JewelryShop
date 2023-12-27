<template>
    <v-card>
        <v-row style="align-items: center;">
            <v-col md="5">
                <v-card-text style="font-size: 20px;">Đơn hàng</v-card-text>
            </v-col>
        </v-row>
        
        <v-table>
            <thead>
                <tr>
                <th class="text-center">
                    ID
                </th>
                <th class="text-left">
                    Khách hàng
                </th>
                <th class="text-left">
                    Ngày đặt
                </th>
                <th class="text-left">
                    Tổng tiền
                </th>
                <th class="text-center">
                    Trạng thái
                </th>
                <th class="text-center">
                    
                </th>
                <th class="text-center">
                    
                </th>
                </tr>
            </thead>
            <tbody>
                <tr
                v-for="item in listOrder"
                :key="item.orderId"
                >
                    <td class="text-left">{{ item.orderId }}</td>
                    <td>{{ item.userName }}</td>
                    <td>{{ item.orderDate.slice(0,10)}}</td>
                    <td>$ {{ item.orderTotal }}</td>
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
                    <td>
                        <v-btn @click="dialogDetail = true, currentItem = item" color="orange" class="mr-3" icon size="x-small">
                            <v-icon>mdi-eye</v-icon>
                        </v-btn>
                        <v-btn 
                            @click="this.changeStatusOrder(item)" 
                            color="orange" class="mr-3" 
                            icon 
                            size="x-small" 
                            v-if="item.orderStatus == 0"
                        >
                            <v-icon>mdi-arrow-right-bold-circle-outline</v-icon>
                        </v-btn>
                    </td>
                </tr>
            </tbody>
        </v-table>

        
    </v-card>

    <admin-detail-order
        :dialogDetail="dialogDetail"
        @close="dialogDetail = false"
        :currentItem = "currentItem"
    />


  </template>
  <script>
  import { mapGetters, mapActions } from 'vuex'
import AdminDetailOrder from './AdminDetailOrder.vue';
    export default {
  components: {AdminDetailOrder },
      data () {
        return {
          jewelryId: '',
          page: 1,
          dialogDetail: false,
          currentItem: '',
        }
      },
      computed:{
        ...mapGetters(['listOrder']),
      },

      created(){
        this.getOrders();
      },

      methods:{
        ...mapActions(['getOrders', 'changeStatusOrder']),
    }
  }
  </script>