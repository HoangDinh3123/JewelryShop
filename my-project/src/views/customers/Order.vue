<template>
  <div>
    <v-row>
        <v-col md="3">
            <v-card
                class="mx-auto"
                width="256"
            >
                <v-layout>
                <v-navigation-drawer permanent absolute>
                    <v-list>
                    <v-list-item
                        prepend-avatar="https://cdn.vuetifyjs.com/images/john.png"
                        :title="user.user.userName"
                        :subtitle="user.user.userEmail"
                    >
                    </v-list-item>
                    </v-list>

                    <v-divider></v-divider>

                    <v-list
                    :lines="false"
                    density="compact"
                    nav
                    >

                    <v-list-item
                        to="/customers/order"
                        color="primary"
                    >
                        <template v-slot:prepend>
                        <v-icon>mdi-format-list-bulleted</v-icon>
                        </template>

                        <v-list-item-title>Đơn hàng</v-list-item-title>
                    </v-list-item>
                    </v-list>
                </v-navigation-drawer>

                <v-main style="height: 354px;"></v-main>
                </v-layout>
            </v-card>
        </v-col>

        <v-col>
            <v-card>
                <v-tabs
                v-model="tab"
                >
                <v-tab value="one">Tất cả</v-tab>
                <v-tab value="two">Đang vận chuyển</v-tab>
                <v-tab value="three">Đã hoàn thành</v-tab>
                </v-tabs>

                <v-card-text>
                <v-window v-model="tab">
                    <v-window-item value="one">
                        <v-card style="padding: 10px;" v-for="item in listOrder" :key="item.orderId">
                            <v-row>
                                <v-col md="9">
                                <v-chip
                                    class="ma-2"
                                    color="pink"
                                    label
                                    style="padding: 30px 10px;"
                                >
                                    <v-icon start icon="mdi-map-marker"></v-icon>
                                    <div class="chip-content">{{item.address}}</div>
                                </v-chip>
                                </v-col>

                                <v-col style="display: flex; align-items: center;">
                                <v-chip
                                    v-if="item.orderStatus"
                                    class="ma-2"
                                    color="pink"
                                    label
                                >
                                    <v-icon start icon="mdi-checkbox-marked-circle-outline"></v-icon>
                                    Đã giao hàng thành công
                                </v-chip>

                                <v-chip
                                    v-if="!item.orderStatus"
                                    class="ma-2"
                                    color="blue"
                                    label
                                >
                                    <v-icon start icon="mdi-car-pickup"></v-icon>
                                    Đang giao hàng
                                </v-chip>
                                </v-col>
                            </v-row>

                            <v-divider></v-divider>

                            <v-row style="padding: 10px;">
                                <v-col md="1">
                                <v-img
                                    src="https://picsum.photos/400/400/?image=20"
                                    alt="Image"
                                    class="rounded"
                                    height="100%"
                                    cover
                                ></v-img>
                                </v-col>
                                <v-col md="10">
                                <p>Tên người nhận: {{ item.userName }}</p>
                                <p style="color: #7d7d7d; font-size: 14px;">Ngày đặt: {{item.orderDate}}</p>
                                <p style="font-size: 14px;">x {{ item.details.length }}</p>
                                </v-col>
                                <v-col>
                                <p style="color: orange;">$ {{ item.orderTotal }}</p>
                                </v-col>
                                <v-divider></v-divider>
                            </v-row>
                        </v-card>
                           
                    </v-window-item>

                    <v-window-item value="two">
                        <v-card style="padding: 10px;" v-for="item in listOrdering" :key="item.orderId">
                            <v-row>
                                <v-col md="9">
                                <v-chip
                                    class="ma-2"
                                    color="pink"
                                    label
                                    style="padding: 30px 10px;"
                                >
                                    <v-icon start icon="mdi-map-marker"></v-icon>
                                    <div class="chip-content">{{item.address}}</div>
                                </v-chip>
                                </v-col>

                                <v-col style="display: flex; align-items: center;">
                                <v-chip
                                    v-if="item.orderStatus"
                                    class="ma-2"
                                    color="pink"
                                    label
                                >
                                    <v-icon start icon="mdi-checkbox-marked-circle-outline"></v-icon>
                                    Đã giao hàng thành công
                                </v-chip>

                                <v-chip
                                    v-if="!item.orderStatus"
                                    class="ma-2"
                                    color="blue"
                                    label
                                >
                                    <v-icon start icon="mdi-car-pickup"></v-icon>
                                    Đang giao hàng
                                </v-chip>
                                </v-col>
                            </v-row>

                            <v-divider></v-divider>

                            <v-row style="padding: 10px;">
                                <v-col md="1">
                                <v-img
                                    src="https://picsum.photos/400/400/?image=20"
                                    alt="Image"
                                    class="rounded"
                                    height="100%"
                                    cover
                                ></v-img>
                                </v-col>
                                <v-col md="10">
                                <p>Tên người nhận: {{ item.userName }}</p>
                                <p style="color: #7d7d7d; font-size: 14px;">Ngày đặt: {{item.orderDate}}</p>
                                <p style="font-size: 14px;">x {{ item.details.length }}</p>
                                </v-col>
                                <v-col>
                                <p style="color: orange;">$ {{ item.orderTotal }}</p>
                                </v-col>
                                <v-divider></v-divider>
                            </v-row>
                        </v-card>
                    </v-window-item>

                    <v-window-item value="three">
                        <v-card style="padding: 10px;" v-for="item in listDone" :key="item.orderId">
                            <v-row>
                                <v-col md="9">
                                <v-chip
                                    class="ma-2"
                                    color="pink"
                                    label
                                    style="padding: 30px 10px;"
                                >
                                    <v-icon start icon="mdi-map-marker"></v-icon>
                                    <div class="chip-content">{{item.address}}</div>
                                </v-chip>
                                </v-col>

                                <v-col style="display: flex; align-items: center;">
                                <v-chip
                                    v-if="item.orderStatus"
                                    class="ma-2"
                                    color="pink"
                                    label
                                >
                                    <v-icon start icon="mdi-checkbox-marked-circle-outline"></v-icon>
                                    Đã giao hàng thành công
                                </v-chip>

                                <v-chip
                                    v-if="!item.orderStatus"
                                    class="ma-2"
                                    color="blue"
                                    label
                                >
                                    <v-icon start icon="mdi-car-pickup"></v-icon>
                                    Đang giao hàng
                                </v-chip>
                                </v-col>
                            </v-row>

                            <v-divider></v-divider>

                            <v-row style="padding: 10px;">
                                <v-col md="1">
                                <v-img
                                    src="https://picsum.photos/400/400/?image=20"
                                    alt="Image"
                                    class="rounded"
                                    height="100%"
                                    cover
                                ></v-img>
                                </v-col>
                                <v-col md="10">
                                <p>Tên người nhận: {{ item.userName }}</p>
                                <p style="color: #7d7d7d; font-size: 14px;">Ngày đặt: {{item.orderDate}}</p>
                                <p style="font-size: 14px;">x {{ item.details.length }}</p>
                                </v-col>
                                <v-col>
                                <p style="color: orange;">$ {{ item.orderTotal }}</p>
                                </v-col>
                                <v-divider></v-divider>
                            </v-row>
                        </v-card>
                    </v-window-item>
                </v-window>
                </v-card-text>
            </v-card>
        </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters, mapMutations, mapActions } from 'vuex'
export default {
    data: () => ({
      tab: null,
    }),
    computed: {
      ...mapGetters(['listOrder', 'user']),
      listOrdering() {
        return this.listOrder.filter(item => !item.orderStatus);
      },
        listDone() {
            return this.listOrder.filter(item => item.orderStatus);
        },
    },
    created(){
      this.getOrdersByUserId();
    },
    methods:{
    ...mapActions(['getOrdersByUserId']),


  }

}
</script>

<style>
.chip-content {
  white-space: normal !important;
  overflow: visible !important;
}

</style>