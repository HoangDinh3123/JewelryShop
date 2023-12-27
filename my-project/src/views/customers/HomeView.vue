<template>
  <div>
    <v-row style="margin-bottom: 40px;">
      <v-col md="8">
       <v-card>
        <v-carousel show-arrows="hover">
          <v-carousel-item
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
            cover
          ></v-carousel-item>

          <v-carousel-item
            src="https://cdn.vuetifyjs.com/images/cards/hotel.jpg"
            cover
          ></v-carousel-item>

          <v-carousel-item
            src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
            cover
          ></v-carousel-item>
        </v-carousel>
       </v-card>
      </v-col>
      <!-- show carousel items -->
      
      <v-col>
        <v-card outline to="/crud" style="text-align: center; height: 500px;">
          <v-img
            class="align-end text-white"
            :aspect-ratio="1"
            src="https://4.bp.blogspot.com/-aCNC9YAKSA4/UkP_GGvMcZI/AAAAAAAAAh0/_QBFRsijhQc/s1600/anh-dep-hinh-nen-thien-nhien-6.jpg"
            cover
            style="height: 100%;"
          >
            <span>FLASH SALE</span>
            <br>
            <span>15 OCTOBER - 15 DECEMBER</span>
          </v-img>
        </v-card>
      </v-col>
    </v-row>
    
    <!-- Show benefits -->
    <v-row style="display: flex; justify-content: center; margin-bottom: 40px;">
      <v-col class="benefit" md="2">    
        <v-img src="https://ninetheme.com/themes/goldsmith/wp-content/uploads/2022/12/033-tag.png"></v-img>
        <span style="display: block; font-weight: bold; ">Amazing Value Every Day</span>
        <span style="font-size: 12px; color: #7d7d7d;">Items prices that fit your budget</span>              
      </v-col>

      <v-col class="benefit" md="2">
        <v-img src="https://ninetheme.com/themes/goldsmith/wp-content/uploads/2022/12/011-best-seller.png"></v-img>
        <span style="display: block; font-weight: bold; ">Successful Customer Service</span>
        <span style="font-size: 12px; color: #7d7d7d;">We work with a focus on 100% customer satisfaction.</span>  
      </v-col>

      <v-col class="benefit" md="2">
        <v-img src="https://ninetheme.com/themes/goldsmith/wp-content/uploads/2022/12/071-credit-card.png"></v-img>
        <span style="display: block; font-weight: bold; ">All Payment Methods</span>
        <span style="font-size: 12px; color: #7d7d7d;">Don't bother with payment details.</span>  
      </v-col>

      <v-col class="benefit" md="2">
        <v-img src="https://ninetheme.com/themes/goldsmith/wp-content/uploads/2022/12/016-fast-delivery.png"></v-img>
        <span style="display: block; font-weight: bold; ">Completely free shipping</span>
        <span style="font-size: 12px; color: #7d7d7d;">We'll handle the shipping.</span>  
      </v-col>
    </v-row>
    <!-- Show benefits -->

    <!-- Show list item -->
    <v-row>
      <v-col md="3">
        <v-img
            src="https://jewellery.thesilkroad.vn/wp-content/uploads/2021/03/166203048-scaled.jpg"
            cover
            style="height: 100%;"
          >
        </v-img>
      </v-col>
      <v-col >
        <v-row>
          <v-col md="3" v-for="jewelry in limitedJewelrys" v-bind:key="jewelry.jewelryId" >
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                :src="jewelry.jewelryImages[0]"
                height="200px"
                cover
              >
                
                <v-btn variant="text" @click="dialogDetail = true, currentItem = jewelry" icon="mdi-eye" color="orange-lighten-2"></v-btn>
              </v-img>

              <v-card-title>
                <a href="/" style="text-decoration: none; color: black; font-size: 16px;">{{ jewelry.jewelryName }}</a>
              </v-card-title>

              <v-card-subtitle>
               $ {{ jewelry.jewelryPrice }}
              </v-card-subtitle>

              <v-card-actions>
                <v-btn
                  color="orange-lighten-2"
                  variant="text"
                  @click="showAlert(jewelry)"
                >
                  Add to cart
                </v-btn>
              </v-card-actions>

            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <!-- Show list item -->

    <pre-detail-jewelry
        :dialogDetail="dialogDetail"
        @close="dialogDetail = false"
        :currentItem = "currentItem"
    />
  </div>

</template>

<script>
import { mapGetters, mapMutations, mapActions } from 'vuex'
import PreDetailJewelry from './PreDetailJewelry.vue';
export default {
  name: 'HomeView',
  components: {
    PreDetailJewelry,
  }
  ,
  data:() => ({
    show: false,
    jewelrys:'',
    dialogDetail: false,
    currentItem: ''
  }),
  computed: {
      ...mapGetters(['listJewelry']),
      limitedJewelrys() {
      // Lấy ra 12 phần tử đầu tiên của mảng jewelrys
      return this.listJewelry.slice(0, 12);
    }
  },
  created(){
      this.getJewelries();
  },
  methods:{
    ...mapActions(['getJewelries', 'getJewelry', 'AddToCart']),

    showAlert(jewelry) {
      this.AddToCart(jewelry);
      // Use sweetalert2
      this.$swal.fire({
        icon: 'success',
        title: 'Success!!!',
        showConfirmButton: false,
        timer: 1500
      })
    }
  }
}
</script>

<style>
  .benefit{
    text-align: center;
  }
  .benefit .v-img{
    width: 100px;
    height: 100px;
    margin: auto;
  }

  .my-dialog {
  z-index: 1;

}
  
</style>
