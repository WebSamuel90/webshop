import React from 'react';
import './Product.css';

const Product = (props) => {

    const productData = props.data;

    return (
        <div className='item'>
            <img src='{productData.image}'/>
            <p>{productData.brand}</p>
            <p>{productData.name}</p>
            <p>{productData.price}</p>
        </div>
    );
};

export default Product;