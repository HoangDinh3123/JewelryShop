<template>
  <div>
    <v-row>
        <v-col md="1">
            <v-card
                v-for="(item,i) in jewelry.jewelryImages"
                :key="i"
                class="mx-auto"
                max-width="200"
                height="100"
                :image= "item"
                theme="dark"
                style="margin-bottom: 5px;"
            ></v-card>
        </v-col>
        <v-col md="6">
            <v-carousel hide-delimiters>
                <v-carousel-item
                v-for="(item,i) in jewelry.jewelryImages"
                :key="i"
                :src="item"
                cover
                ></v-carousel-item>
            </v-carousel>
        </v-col>

        <v-col>
            <p style="font-size: 25px; font-weight: bold;">{{ jewelry.jewelryName }}</p>

            <p style="margin: 10px 0; color: #7d7d7d;">{{ jewelry.jewelryDescription }}</p>

            <p style="font-size: 14px;">$ {{ jewelry.jewelryPrice }}</p>

            <p style="margin: 10px 0;"><span style="color: #7d7d7d;">DANH MỤC:</span> {{ jewelry.categoryName }}</p>

            <v-btn style="top: 10px;" color="red" append-icon="mdi-cart-arrow-down"  @click="showAlert(jewelry)">
                Thêm giỏ hàng
            </v-btn>
        </v-col>
    </v-row>
    <v-row>
        <v-col md="12">
            <v-card>
                <v-tabs
                v-model="tab"
                contain
                >
                <v-tab value="one">Thông tin thêm</v-tab>
                <v-tab value="two">Đánh giá ({{ listReview.length }})</v-tab>
                </v-tabs>

                <v-card-text>
                <v-window v-model="tab">
                    <v-window-item value="one">
                    <p><span style="color: #7d7d7d;">Cân nặng</span> {{ jewelry.jewelryWeight }}</p>
                    <p><span style="color: #7d7d7d;">Kích thước</span> {{ jewelry.jewelrySize }}</p>
                    <p><span style="color: #7d7d7d;">Màu sắc</span> {{ jewelry.jewelryColor }}</p>
                    </v-window-item>

                    <!-- Đánh giá -->
                    <v-window-item value="two" >

                            <div class="d-flex ma-2 justify-center">
                                Điểm đánh giá: {{ this.ratingPoint() }}
                            </div>
                            <v-form>
                                <div class="d-flex justify-center">
                                    <v-textarea
                                        v-model="this.review.jewelryReviewComment"
                                        append-inner-icon="mdi-comment"
                                        class="mx-2"
                                        label="Nhập nội dung"
                                    ></v-textarea>
                                </div>

                                <div class="d-flex justify-center">
                                    <v-rating v-model="this.review.jewelryReviewRating"></v-rating>
                                </div>

                                <v-btn style="top: 10px;" color="red"  @click="Review(this.review)">
                                    Gửi đánh giá
                                </v-btn>
                            </v-form>



                            <v-card
                                class="mx-auto"
                                max-width="450"
                                style="margin-bottom: 10px;"
                            >

                            <v-list-item
                                v-for="item in listReview"
                                style="margin: 10px;"
                                :key="item.id"
                                prepend-avatar="https://cdn.vuetifyjs.com/images/lists/1.jpg"
                                :title="item.userName"
                                :subtitle="item.reviewDate"
                            >

                                <v-list-item-content>
                                    <div class="d-flex ma-2">
                                        <v-rating size="20" v-model="item.jewelryReviewRating"></v-rating>
                                    </div>
                                <v-list-item-subtitle>{{ item.jewelryReviewComment }}</v-list-item-subtitle>
                                </v-list-item-content>
                                <v-divider></v-divider>
                            </v-list-item>
                            </v-card>
                    </v-window-item>

                </v-window>
                </v-card-text>
            </v-card>
        </v-col>


        <!-- Có thể thích -->
        <v-col>
            <h3>Bạn có thể thích</h3>
            <v-sheet
                class="mx-auto"

            >
                <v-slide-group
                v-model="model"
                class="pa-4"
                selected-class="bg-success"
                show-arrows
                >
                    <v-slide-group-item
                        v-for="item in listJewelry"
                        :key="item.jewelryId"
                    >
                        <v-card
                        class="ma-4"
                        height="300"
                        width="250px"
                        style="cursor: pointer;"
                        >
                            <v-img
                                :src="item.jewelryImages[0]"
                                height="300px"
                                cover
                            >
                                
                            </v-img>

                            <v-card-title>
                                <a href="/" style="text-decoration: none; color: black; font-size: 16px;">{{ item.jewelryName }}</a>
                            </v-card-title>

                            <v-card-subtitle>
                                {{ item.jewelryPrice }}
                            </v-card-subtitle>

                            <v-card-actions>
                                <v-btn
                                color="orange-lighten-2"
                                variant="text"
                                @click="showAlert(item)"
                                >
                                Add to cart
                                </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-slide-group-item>
                </v-slide-group>
            </v-sheet>
        </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
    data(){
        return{
            tab: null,
            model: null,
            rating: '',
            review: {
                jewelryReviewComment: '',
                jewelryReviewRating: 0, 
                jewelryId: '',
                reviewDate: '',
                userId: ''
            },
        }
    },
    computed:{
        ...mapGetters(['jewelry', 'listJewelry', 'listReview', 'token','user'])
    },

    methods:{
        ...mapActions(['getJewelry', 'getJewelryByCategoryId', 'AddToCart', 'getReviews', 'addReview']),
        showAlert(jewelry) {
            this.AddToCart(jewelry);
            // Use sweetalert2
            this.$swal.fire({
                icon: 'success',
                title: 'Success!!!',
                showConfirmButton: false,
                timer: 1500
        })},
        Review(reviewContent) {
            var today = new Date();
            reviewContent.jewelryId = this.jewelry.jewelryId;
            reviewContent.userId = this.user.user.userId;
            reviewContent.reviewDate = today;
            this.addReview(reviewContent);
            // Use sweetalert2
            this.$swal.fire({
                icon: 'success',
                title: 'Success!!!',
                showConfirmButton: false,
                timer: 1500
        })},
        ratingPoint(){
            var point = 0;
            for(let i = 0; i < this.listReview.length; i++)
            {
                point = point + this.listReview[i].jewelryReviewRating;
            }
            var ratingpoint = point / this.listReview.length;
            return ratingpoint.toFixed(1);
        }
},

    mounted(){
        var id = this.$route.params.id;
        var categoryId = this.$route.params.category;
        this.getJewelry(id);
        console.log(categoryId);
        this.getJewelryByCategoryId(categoryId);
        this.getReviews(id);
    }
}
</script>

<style>

</style>