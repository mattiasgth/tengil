import React, { useState, useEffect } from 'react';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { Container, TextField, Button, Grid } from '@mui/material';
import { TngInvoice } from '../../model/invoice';
import dayjs from 'dayjs';
import { DatePicker } from '@mui/x-date-pickers';

const API_ENDPOINT = 'https://localhost:7120';

interface InvoiceDetailProps {
  selectedInvoice: TngInvoice | null;
  updateSelectedInvoice: (invoice: TngInvoice) => void;
  save: () => void;
}
const InvoiceDetail: React.FC<InvoiceDetailProps> = ({ selectedInvoice, updateSelectedInvoice, save }) => {


  return (
    <Grid item xs={6}>
      {selectedInvoice ? (
        <div>
          <h2>Invoice Details</h2>
          <Grid container spacing={8}>
            <Grid item xs={6}>
              <TextField
                label="Invoice Text"
                value={selectedInvoice.invoiceText}
                onChange={(e) => updateSelectedInvoice({ ...selectedInvoice, invoiceText: e.target.value })}
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                label="Amount"
                type="number"
                value={selectedInvoice.amount || ''}
                onChange={(e) => updateSelectedInvoice({ ...selectedInvoice, amount: parseFloat(e.target.value) })}
              />
            </Grid>
            <Grid item xs={6}>
              <DatePicker label="Paid date"
                value={selectedInvoice.datePaid}
                onChange={(date) => updateSelectedInvoice({ ...selectedInvoice, datePaid: date })}
              />
            </Grid>
            <Grid item xs={6}>
              <DatePicker label="Issued"
                value={selectedInvoice.dateIssued}
                onChange={(date) => updateSelectedInvoice({ ...selectedInvoice, dateIssued: date })}
              />
            </Grid>
            <Grid item xs={6}>
              <DatePicker label="Due"
                value={selectedInvoice.dateDue}
                onChange={(date) => updateSelectedInvoice({ ...selectedInvoice, dateDue: date })}
              />
            </Grid>
            <Grid item xs={6}>
            </Grid>
            <Grid item xs={6}>
            </Grid>
            <Grid item xs={6}>
            </Grid>
          </Grid>
          <Button variant="contained" color="primary" onClick={save}>
            Save
          </Button>
        </div>

      ) : (
        <div>No invoice selected</div>
      )}
    </Grid>
  );
};

export default InvoiceDetail;
