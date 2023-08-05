import { Button, Checkbox, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControl, FormControlLabel, Grid, InputLabel, MenuItem, Paper, Select, styled, TextField } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { useEffect, useState } from "react";
import { TngCustomerListing } from "../../model/customer-listing";
import { TngStatusValue } from "../../model/status-value";
import { TngUser } from "../../model/user";

const API_ENDPOINT = 'https://localhost:7120';

export default function AddEditAssignment(props: { open: boolean, handleClose: () => void }) {

  const [customers, setCustomers] = useState<TngCustomerListing[]>([]);
  const [statusValues, setStatusValues] = useState<TngStatusValue[]>([]);
  const [owners, setOwners] = useState<TngUser[]>([]);

  useEffect(() => {
    fetchCustomers();
    fetchStatusValues();
    setOwners([{
      id: 1,
      username: 'marfuas',
      firstName: 'Mattias',
      lastName: 'Göthe'
    }]);
  }, []);

  const fetchCustomers = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/customers?take=9999`);
      const data = await response.json();
      setCustomers(data.map((customer: any) => {
        return {
          ...customer
        };
      }));
    } catch (error) {
      console.error('Error fetching customers:', error);
    }
  };

  const fetchStatusValues = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/statusValues`);
      const data = await response.json();
      setStatusValues(data.map((status: any) => {
        return {
          ...status
        };
      }));
    } catch (error) {
      console.error('Error fetching status values:', error);
    }
  };

  return (
    <Dialog open={props.open} onClose={props.handleClose}>
      <DialogTitle>Add/Edit Assignment</DialogTitle>
      <DialogContent>
        <DialogContentText>
          To subscribe to this website, please enter your email address here. We
          will send updates occasionally.
        </DialogContentText>
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <FormControl fullWidth>
              <InputLabel htmlFor="customer-select" id="customer-select-label">
                Customer
              </InputLabel>
              <Select
                autoFocus
                fullWidth
                label="Customer"
                id="customer-select"
                labelId="customer-select-label"
              >
                {customers.map(item => {
                  return (<MenuItem value={item.id} key={item.id}>{item.name}</MenuItem>);
                }
                )}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <TextField
              margin="dense"
              id="contact-email"
              label="Contact Email"
              type="email"
              fullWidth
              variant="standard"
            />
          </Grid>
          <Grid item xs={6}>
            <FormControl fullWidth>
              <InputLabel htmlFor="owner-select" id="owner-select-label">
                Owner
              </InputLabel>
              <Select
                autoFocus
                fullWidth
                label="Owner"
                id="owner-select"
                labelId="owner-select-label"
              >
                {owners.map(item => {
                  return (<MenuItem value={item.id} key={item.id}>{item.username}</MenuItem>);
                }
                )}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl fullWidth>
              <InputLabel htmlFor="status-select" id="status-select-label">
                Status
              </InputLabel>
              <Select
                fullWidth
                label="Status"
                id="status-select"
                labelId="status-select-label"
              >
                {statusValues.map(item => {
                  return (<MenuItem value={item.id} key={item.id}>{item.text}</MenuItem>);
                }
                )}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <TextField
              id="nameText"
              label="Text"
              fullWidth
            />
          </Grid>
          <Grid item xs={6}>
            <DatePicker
              label="Date"
              slotProps={{ textField: { fullWidth: true } }}
            />
          </Grid>
          <Grid item xs={6}>
            <DatePicker
              label="Deadline"
              slotProps={{ textField: { fullWidth: true } }}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="folder"
              label="Folder"
              fullWidth
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              id="po-text"
              label="Purchase Order"
              fullWidth
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              id="comment-text"
              label="Comment"
              fullWidth
            />
          </Grid>
          <Grid item>
            <FormControlLabel control={<Checkbox defaultChecked />} label="Active" />
          </Grid>
        </Grid>
      </DialogContent>
      <DialogActions>
        <Button onClick={props.handleClose}>OK</Button>
        <Button onClick={props.handleClose}>Cancel</Button>
      </DialogActions>
    </Dialog>);
};