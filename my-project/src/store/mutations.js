export default{
    setUser(state, user){
        state.user = user;
    },
    clearUser(state) {
        state.user = null;
      },
    setListJewelry(state, listJewelry){
        state.listJewelry = listJewelry;
    },
    
    setJewelry(state, jewelry){
        state.jewelry = jewelry;
    },

    addJewelry(state, jewelry)
    {
        state.listJewelry.push(jewelry);
    },

    updateJewelry(state, editedJewelry)
    {
        const id = state.listJewelry.findIndex(item => item.jewelryId == editedJewelry.jewelryId);
        state.listJewelry[id] = editedJewelry;
    },

    deleteJewelry(state, id){
        const jewelry = state.listJewelry.findIndex(item => item.jewelryId == id);
        state.listJewelry.splice(jewelry, 1);
    },

    addToCart(state, jewelry){
        state.cart.push({
            itemCart: jewelry,
            quantity: 1
        });
    },

    deleteItemCart(state, jewelryId){
        const itemCart = state.cart.findIndex(i => i.itemCart.jewelryId == jewelryId);
        if(itemCart != null){
            state.cart.splice(itemCart, 1);
        }
    },

    setListCategory(state, categories){
        state.listCategory = categories;
    },

    setCategory(state, category){
        state.category = category;
    },

    addCategory(state, category)
    {
        state.listCategory.push(category);
    },

    updateCategory(state, editedCategory)
    {
        const id = state.listCategory.findIndex(item => item.categoryId == editedCategory.categoryId);
        state.listCategory[id] = editedCategory;
    },

    deleteCategory(state, id){
        const category = state.listCategory.findIndex(item => item.categoryId == id);
        state.listCategory.splice(category, 1);
    },
    setListOrder(state, orders){
        state.listOrder = orders;
    },
    setOrder(state, order){
        state.order = order;
    },
    addOrder(state, order)
    {
        state.listOrder.push(order);
    },
    changeStatusOrder(state, order)
    {
        const id = state.listOrder.findIndex(item => item.orderId == order.orderId);
        state.listOrder[id] = order;
    },

    setlistOrderDetail(state, orderDetails){
        state.listOrderDetail = orderDetails;
    },
    
    setlistCustomer(state, customers){
        state.listCustomer = customers;
    },

    incrementCartQuantity(state, item){
        item.quantity++;
    },

    decrementCartQuantity(state, item){
        item.quantity--;
    },

    setListReview(state, review){
        state.listReview = review;
    },

    setReview(state, review){
        state.review = review;
    },

    addReview(state, review)
    {
        state.listReview.push(review);
    },

}