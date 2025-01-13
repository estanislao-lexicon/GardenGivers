import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { searchProductById } from './api';

// Create root element
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

console.log(searchProductById("apples"));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

// Pass a callback to log the web vitals (or send to an analytics endpoint)
reportWebVitals(console.log);
