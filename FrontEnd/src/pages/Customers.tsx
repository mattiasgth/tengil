import { Container, Grid } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { TngCustomerListing } from "../model/customer-listing";


const API_ENDPOINT = 'https://localhost:7120';

const columns: GridColDef[] = [
  { field: 'id', headerName: 'ID', width: 7 },
  { field: 'name', headerName: 'Name', width: 120 }
];

const Customers: React.FC = () => {

  const [customers, setCustomers] = useState<TngCustomerListing[]>([]);

  useEffect(() => {
    fetchCustomers();
  }, []);

  const fetchCustomers = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/customers`);
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

  return (
    <Container>
      <h1>Customers</h1>
      <Grid container>
        <Grid item>
          <DataGrid
            rows={customers}
            columns={columns}
          />
        </Grid>
      </Grid>
    </Container>);
};

export default Customers;