<template>
  <v-dialog
      v-model="dialog"
      scrollable
      width="500px"
    >
      <v-card
    class="mx-auto"
  >

    <v-container>
      <h3>Chi tiet don hang</h3>
      <v-row dense>

        <v-col 
            cols="12" 
            v-for="item in this.data.details"
            :key="item.orderDetailId">
          <v-card
            color="#952175"
            style="margin-bottom: 10px;"
          >
            <div class="d-flex flex-no-wrap justify-space-between">
              <div>
                <v-card-title class="text-h5">
                  {{ item.jewelryName }}
                </v-card-title>

                <v-card-subtitle>Số lượng: {{ item.quantity }}</v-card-subtitle>
                <v-card-text>Tổng tiền: {{ item.orderDetailPrice }}</v-card-text>
              </div>

              <v-avatar
                class="ma-3"
                size="125"
                rounded="0"
              >
                <v-img :src="item.jewelryImagePath"></v-img>
              </v-avatar>
            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
    </v-dialog>
</template>

<script>
import { mapActions,mapGetters } from 'vuex';
export default {
    name:'AdminDetailOrder',
      data(){
          return{
              data:{
                details: [],
              },
          }
      },

      props:['dialogDetail', 'currentItem'],

      computed:{
          dialog:{
              get(){
                  return this.dialogDetail;
              },
              set(value){
                  if(!value){
                      this.$emit('close');
                  }
              }
          }
      },
      created(){
        
      },
      methods:{
        
        
        },

      watch:{
        currentItem:function(){
            this.data.details = this.currentItem.details;
        }
        },
}
</script>

<style>

</style>