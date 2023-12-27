import axios from 'axios'
import router from '../router'
import state from './state'
export default{
    getJewelries({commit}){
        axios.get('https://localhost:7198/api/Jewelry')
        .then(response=>{
            commit("setListJewelry", response.data);
        }).catch(e => {
            console.log("Error");
        })
    },

    async getJewelry({commit}, id){   
        axios.get('https://localhost:7198/api/Jewelry' + "/" + id)
            .then(response =>{
                if(response.data){
                    commit("setJewelry", response.data);
                }
            })
    },

    getJewelryByCategoryId({commit}, id){   
        console.log(id);    
        axios.get('https://localhost:7198/api/Jewelry/byCategory?id=' + id)
            .then(response =>{
                if(response.data){
                    commit("setListJewelry", response.data);
                }
            })
    },

    addJewelry({commit}, jewelry) {
        return axios.post("https://localhost:7198/api/Jewelry", jewelry)
            .then(response => {
                commit("addJewelry", category);
                return response.data;
            }).catch(e=>{
                console.log("Error:", e);
            })
    },

    updateJewelry({commit}, jewelry)
    {
        return axios.put("https://localhost:7198/api/Jewelry" + "/" + jewelry.jewelryId, jewelry)
            .then(response => {
                commit("updateJewelry", jewelry);
            }).catch(e=>{
                console.log("Error:", e);
            })
    },

    deleteJewelry({commit}, id)
    {
        axios.delete('https://localhost:7198/api/Jewelry' + '/' + id)
        .then(response => {
          if(response.data){
            commit("deleteJewelry", id);
          }
        }).catch(e => {
            console.log("Error");
        })
    },

    AddToCart({commit}, jewelry){
        const item = state.cart.find(i => i.itemCart.jewelryId === jewelry.jewelryId);       
        if(!item)
        {
            commit("addToCart", jewelry);
        }
        else
            commit("incrementCartQuantity", item);
    },

    DeleteItemCart({commit}, jewelryId){
        const item = state.cart.findIndex(i => i.itemCart.id === jewelryId);
        if(item != null)
        {
            commit("deleteItemCart", jewelryId);
        }
        else
            console.error("Khong ton tai san pham trong gio hang!!");
               
    },

    getCategories({commit}){
        axios.get('https://localhost:7198/api/Category')
        .then(response=>{
            commit("setListCategory", response.data);
        }).catch(e => {
            console.log("Error");
        })
    },


    addCategory({commit}, category)
    {
        return axios.post("https://localhost:7198/api/Category", category)
            .then(response => {
                commit("addCategory", category);
                return response.data;
            }).catch(e=>{
                console.log("Error:", e);
            })
    },

    updateCategory({commit}, category)
    {
        return axios.put("https://localhost:7198/api/Category" + "/" + category.categoryId, category)
            .then(response => {
                commit("updateCategory", category);
            }).catch(e=>{
                console.log("Error:", e);
            })
    },

    deleteCategory({commit}, id)
    {
        axios.delete('https://localhost:7198/api/Category' + '/' + id)
        .then(response => {
          if(response.data){
            commit("deleteCategory", id);
          }
        }).catch(e => {
            console.log("Error");
        })
    },
    getImages({commit}, id){   
        axios.get('https://localhost:7198/api/Jewelry/GetImagesByJewelry?jewelryId=' + id)
            .then(response =>{
                if(response.data){
                    commit("setJewelry", response.data);
                    console.log(response.data);
                }
            })
    },

    getOrders({commit}){
        axios.get('https://localhost:7198/api/Order')
        .then(response=>{
            commit("setListOrder", response.data);
        }).catch(e => {
            console.log("Error");
        })
    },

    changeStatusOrder({commit}, order)
    {
        order.orderStatus++;
        return axios.put("https://localhost:7198/api/Order", order)
            .then(response => {
                commit("changeStatusOrder", order);
            }).catch(e=>{
                console.log("Error:", e);
            })
    },

    getCustomers({commit}){
        axios.get('https://localhost:7198/api/User')
        .then(response=>{
            commit("setlistCustomer", response.data);
        }).catch(e => {
            console.log("Error");
        })
    },

    login({commit}, user) {
        return axios.post("https://localhost:7198/api/User/login", user)
            .then(response => {
                commit("setUser", response.data);
                console.log(response.data.user.userPermission);
                if(response.data.user.userPermission == 1)
                {
                    router.push('/admin/dashboard');
                }
                else
                    router.push('/');
            }).catch(e=>{
                console.log("Error:", e);
            })
    },
    logout({ commit }) {
        commit("clearUser");
        router.push('/login');
      },
    signup({commit}, user) {
        return axios.post("https://localhost:7198/api/User", user)
            .then(response => {
                return response.data;
            }).catch(e=>{
                console.log("Error:", e);
            })
    },

    getReviews({commit}, id){
        axios.get('https://localhost:7198/api/JewelryReview?id=' + id)
        .then(response=>{
            commit("setListReview", response.data);
        }).catch(e => {
            console.log("Error");
        })
    },

    addReview({commit}, review)
    {
        // , {
        //     headers: { 'Authorization': 'Bearer ' + this.state.user.token}
        // }
        return axios.post("https://localhost:7198/api/JewelryReview", review)
            .then(response => {
                commit("addReview", review);
                return response.data;
            }).catch(e=>{
                console.log("Error:", e);
            })
    },

    addOrder({ commit }, order) {
        return axios.post("https://localhost:7198/api/Order", order)
          .then(() => axios.get("https://localhost:7198/api/Order/latest"))
          .then(response1 => {
            console.log(state.cart.length);
            const detailPromises = state.cart.map(item => {
              const detail = {
                Quantity: item.quantity,
                OrderDetailPrice: item.itemCart.jewelryPrice * item.quantity,
                OrderId: response1.data,
                JewelryId: item.itemCart.jewelryId,
              };
              return axios.post("https://localhost:7198/api/OrderDetail", detail);
            });
      
            return Promise.all(detailPromises);
          })
          .then(responses => {
            // Xử lý các responses nếu cần
            console.log(responses);
          })
          .catch(e => {
            console.log("Error:", e);
          });
      },

      getOrdersByUserId({ commit, state }) {
          return axios.get('https://localhost:7198/api/Order/getOrder?id=' + state.user.user.userId)
            .then(response => {
              commit("setListOrder", response.data);
              return response.data;
            })
            .catch(e => {
              console.log("Error:", e);
            });
      },
      

}