import React from 'react';
import logo from './logo.svg';
import './App.css';
import TopMenu from './TopMenuBar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Assignments from './pages/Assignments';
import PurchaseOrders from './pages/PurchaseOrders';
import Customers from './pages/Customers';
import InvoiceManagement from './pages/invoices/InvoiceMaster';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'

function App() {
  return (
    <BrowserRouter>
      <TopMenu />
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <Routes>
          <Route path="/assignments" element={<Assignments />} />
          <Route path="/purchase-orders" element={<PurchaseOrders />} />
          <Route path="/invoices" element={<InvoiceManagement />} />
          <Route path="/customers" element={<Customers />} />
        </Routes>
      </LocalizationProvider>
</BrowserRouter>
  );
}

export default App;
