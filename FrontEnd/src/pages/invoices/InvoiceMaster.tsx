import React, { useState, useEffect } from 'react';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { Container, TextField, Button, Grid } from '@mui/material';
import { TngInvoice } from '../../model/invoice';
import dayjs from 'dayjs';
import { DatePicker } from '@mui/x-date-pickers';
import InvoiceDetail from './InvoiceDetail';
import { TngInvoiceListing } from '../../model/invoice-listing';

const API_ENDPOINT = 'https://localhost:7120';

const columns: GridColDef[] = [
  { field: 'id', headerName: 'ID', width: 7 },
  { field: 'invoiceText', headerName: 'Invoice Text', width: 120 },
  { field: 'amount', headerName: 'Net', width: 120, type: 'number' },
  {
    field: 'total', headerName: 'Total', width: 120, type: 'number', valueGetter: (params) => {
      return params.row.vat + params.row.amount;
    }
  },
  {
    field: 'dateIssued', headerName: 'Issued', width: 120, type: 'date', valueGetter: (params) => {
      if (!params.value) return null;
      return params.value.toDate();
    }
  },
];

const InvoiceManagement: React.FC = () => {
  const [invoices, setInvoices] = useState<TngInvoiceListing[]>([]);
  const [selectedInvoice, setSelectedInvoice] = useState<TngInvoice | null>(null);
  const [newInvoice, setNewInvoice] = useState<TngInvoice>({
    id: 0,
    datePaid: null,
    dateIssued: null,
    invoiceText: '',
    rate: 0,
    discount: 0,
    rounding: 0,
  });

  useEffect(() => {
    fetchInvoices();
  }, []);

  const fetchInvoiceFromListing = async (listing: TngInvoiceListing) => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/invoices/${listing.id}`);
      let invoice: TngInvoice = await response.json() as TngInvoice;
      invoice.dateDue = dayjs(invoice.dateDue);
      invoice.dateIssued = dayjs(invoice.dateIssued);
      invoice.datePaid = dayjs(invoice.datePaid);
      setSelectedInvoice(invoice);
    } catch (error) {
      console.error('Error fetching invoices:', error);
    }
  }

  const fetchInvoices = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/invoices?take=9999`);
      const data = await response.json();
      setInvoices(data.map((invoice: any) => {
        return {
          ...invoice,
          dateIssued: invoice.dateIssued ? dayjs(invoice.dateIssued) : null
        };
      }));
    } catch (error) {
      console.error('Error fetching invoices:', error);
    }
  };

  const addInvoice = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/invoices`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newInvoice),
      });

      if (response.ok) {
        fetchInvoices();
        setNewInvoice({
          id: 0,
          datePaid: null,
          dateIssued: null,
          invoiceText: '',
          rate: 0,
          discount: 0,
          rounding: 0,
        });
      } else {
        console.error('Error adding invoice:', response.statusText);
      }
    } catch (error) {
      console.error('Error adding invoice:', error);
    }
  };

  const saveInvoice = async () => {
    if (selectedInvoice) {
      try {
        const response = await fetch(`${API_ENDPOINT}/api/invoices/${selectedInvoice.id}`, {
          method: 'PUT',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(selectedInvoice),
        });
      } catch (error) {
        console.error('Error saving invoice:', error);
      }
    }
  };


  return (
    <Container>
      <h1>Invoice Management</h1>
      <Grid container spacing={8}>
        <Grid item xs={6}>
          <div style={{ height: 400, width: '100%' }}>
            <DataGrid
              rows={invoices}
              columns={columns}
              onRowClick={(params) => fetchInvoiceFromListing(params.row as TngInvoiceListing) }
            />
          </div>
        </Grid>
        <InvoiceDetail selectedInvoice={selectedInvoice} save={() => saveInvoice()}
          updateSelectedInvoice={(invoice) => setSelectedInvoice(invoice)} />
      </Grid>
      <h2>Add Invoice</h2>
      <form onSubmit={addInvoice}>
        <TextField
          label="Title"
          value={newInvoice.invoiceText}
          onChange={(e) => setNewInvoice({ ...newInvoice, invoiceText: e.target.value })}
        />
        <TextField
          label="Amount"
          type="number"
          value={newInvoice.amount}
          onChange={(e) => setNewInvoice({ ...newInvoice, amount: parseFloat(e.target.value) })}
        />
        <Button type="submit" variant="contained" color="primary">
          Add Invoice
        </Button>
      </form>
    </Container>
  );
};

export default InvoiceManagement;
