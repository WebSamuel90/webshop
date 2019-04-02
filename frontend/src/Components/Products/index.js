import React, { Component } from 'react';
import Product from '../Product/';

import './Products.css'

class Products extends Component {
    state = {
        products: []
    };

    componentDidMount() {
        this.fetchProducts();
    };

    fetchProducts = () => {
        const api = `http://localhost:2852/api/products`;

        fetch(api)
        .then(res => res.json())
        .then(data => {
            console.log(data)
            this.setState({
                products: data
            });  
        });
    };

    render() {
        return (
            <div className='items'>
                {this.state.products.map(product => <Product data={product} />)}
            </div>
        );
    }
}

export default Products;