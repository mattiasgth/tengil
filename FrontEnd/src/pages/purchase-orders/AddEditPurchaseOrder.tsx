import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControl, Grid, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { DatePicker } from "@mui/x-date-pickers";
import { Form, Formik, useFormik } from "formik";
import { useContext, useEffect, useState } from "react";
import DatePickerFormik from "../../mui-formik/DatePickerFormik";
import { TngCustomerListing } from "../../model/customer-listing";
import { TngInvoiceRow } from "../../model/invoice-row";
import { TngPoInListing } from "../../model/po-listing";
import { TngUnit } from "../../model/unit";
import SelectFormik from "../../mui-formik/SelectFormik";
import TextFieldFormik from "../../mui-formik/TextFieldFormik";

const API_ENDPOINT = 'https://localhost:7120';

const columns: GridColDef[] = [
  { field: 'id', headerName: 'ID', width: 7 },
  { field: 'rowText', headerName: 'Text', width: 120 },
  { field: 'unitId', headerName: 'Unit', width: 32 },
  { field: 'extent', headerName: 'Extent', width: 32 },
  { field: 'pricePerUnit', headerName: 'Price', width: 32 },
  { field: 'vat', headerName: 'VAT', width: 32 }
];

type AddEditPurchaseOrderProps = {
  open: boolean;
  handleClose: () => void;
  purchaseOrder: TngPoInListing;
  customers: TngCustomerListing[];
  units: TngUnit[];
}

export default function AddEditPurchaseOrder(props: AddEditPurchaseOrderProps) {

  const [invoiceRows, setInvoiceRows] = useState<TngInvoiceRow[]>([]);

  useEffect(() => {
    if (props.purchaseOrder.id > 0) {
      fetchInvoiceRows();
    }
    else {
      setInvoiceRows([]);
    }
  }, []);


  const fetchInvoiceRows = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/poins/${props.purchaseOrder.id}/rows`);
      const data = await response.json();
      setInvoiceRows(data.map((row: any) => {
        return {
          ...row
        };
      }));
    } catch (error) {
      console.error('Error fetching invoice rows:', error);
    }
  };

  return (
    <Dialog open={props.open} onClose={props.handleClose}>
      <Formik
        initialValues={{
          ...props.purchaseOrder,
          customerId: props.purchaseOrder.customerId ?? ''
        }}
        onSubmit={(values) => {
          alert(JSON.stringify(values, null, 2));
        }}
      >
        <Form>
          <DialogTitle>{(props.purchaseOrder && props.purchaseOrder.id > 0) ? "Edit Purchase Order" : "Add PurchaseOrder"}</DialogTitle>
          <DialogContent>
            <DialogContentText>
              To subscribe to this website, please enter your email address here. We
              will send updates occasionally.
            </DialogContentText>
            <Grid container spacing={2}>
              <Grid item xs={6}>
                <FormControl fullWidth>
                  <InputLabel htmlFor="customerId" id="customer-select-label">
                    Customer
                  </InputLabel>
                  <SelectFormik
                    autoFocus
                    fullWidth
                    label="Customer"
                    id="customerId"
                    labelId="customer-select-label"
                    name="customerId"
                  >
                    {props.customers.map(item => {
                      return (<MenuItem value={item.id} key={item.id}>{item.name}: {item.id}</MenuItem>);
                    }
                    )}
                  </SelectFormik>
                </FormControl>
              </Grid>
              <Grid item xs={6}>
                <DatePickerFormik
                  name="dateIn"
                  label="Date"
                  slotProps={{ textField: { fullWidth: true } }}
                />
              </Grid>
              <Grid item xs={12}>
                <TextFieldFormik name="nameText" id="nameText"
                  fullWidth
                  label="Text"
                ></TextFieldFormik>
              </Grid>
              <Grid item xs={6}>
              </Grid>
              <Grid item xs={12}>
                <DataGrid
                  style={{ height: '220px' }}
                  autoPageSize
                  rows={invoiceRows}
                  columns={columns}
                />
              </Grid>
            </Grid>
          </DialogContent>
          <DialogActions>
            <Button type="submit">OK</Button>
            <Button onClick={props.handleClose}>Cancel</Button>
          </DialogActions>
        </Form>
      </Formik>
    </Dialog>);
}