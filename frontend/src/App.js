import React, { Component } from 'react';
import Products from './Components/Products/'

class App extends Component {
  render() {
    return (
      <div className='wrapper'>
        <div className='box A'>A</div>
        <div className='box B'>B</div>
        <div className='box C'>C</div>
        <div className='box D'>
          <div className='items'>
            <Products />
          </div>
        </div>
        <div className='box E'>E</div>
      </div>
    );
  }
}

export default App;
