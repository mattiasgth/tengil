import { Button, Container, Grid, Stack } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import dayjs from "dayjs";
import { useEffect, useState } from "react";
import { TngPoInListing } from "../model/po-listing";

const API_ENDPOINT = 'https://localhost:7120';

const columns: GridColDef[] = [
  { field: 'id', headerName: 'ID', width: 7 },
  { field: 'nameText', headerName: 'Text', width: 220 },
  {
    field: 'dateIn', headerName: 'Date', width: 120, type: 'date', valueGetter: (params) => {
      if (!params.value) return null;
      return params.value.toDate();
    }
  },
  { field: 'customerName', headerName: 'Customer', width: 120 },
  { field: 'amount', headerName: 'Amount', type: 'number', width: 120 },
];

const PurchaseOrders: React.FC = () => {

  const [purchaseOrders, setPurchaseOrders] = useState<TngPoInListing[]>([]);

  useEffect(() => {
    fetchPurchaseOrders();
  }, []);

  const fetchPurchaseOrders = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/poins?take=9999`);
      const data = await response.json();
      setPurchaseOrders(data.map((po: any) => {
        return {
          ...po,
          dateIn: po.dateIn ? dayjs(po.dateIn) : null
        };
      }));
    } catch (error) {
      console.error('Error fetching purchase orders:', error);
    }
  };

  return (
    <Container>
      <h1>Purchase Orders</h1>
      <Stack style={{ width: '100%' }} alignItems="flex-start" spacing={2}>
        <div style={{ height: '500px', width: '100%' }}>
          <DataGrid
            autoPageSize
            rows={purchaseOrders}
            columns={columns}
          />
        </div>
        <Button type="button" variant="contained" color="primary">Add...</Button>
      </Stack>
    </Container>);
};

export default PurchaseOrders;