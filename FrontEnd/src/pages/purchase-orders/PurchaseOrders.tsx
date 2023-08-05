import { Button, Container, Grid, Stack } from "@mui/material";
import { DataGrid, GridColDef, GridEventListener } from "@mui/x-data-grid";
import dayjs, { Dayjs } from "dayjs";
import { useEffect, useState } from "react";
import { TngCustomerListing } from "../../model/customer-listing";
import { TngPoInListing } from "../../model/po-listing";
import { TngUnit } from "../../model/unit";
import AddEditPurchaseOrder from "./AddEditPurchaseOrder";

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
  const [selectedPurchaseOrder, setSelectedPurchaseOrder] = useState<number>(-1);
  const [addEditDialogOpen, setAddEditDialogOpen] = useState(false);
  const [units, setUnits] = useState<TngUnit[]>([]);
  const [customers, setCustomers] = useState<TngCustomerListing[]>([]);

  const handleAddEditDialogClose = () => {
    setAddEditDialogOpen(false);
  };

  const handleAddClicked = () => {
    setSelectedPurchaseOrder(0);
    setAddEditDialogOpen(true);
  };

  useEffect(() => {
    fetchPurchaseOrders();
    fetchCustomers();
    fetchUnits();
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

  const fetchUnits = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/units`);
      const data = await response.json();
      setUnits(data.map((unit: any) => {
        return {
          ...unit
        };
      }));
    } catch (error) {
      console.error('Error fetching units:', error);
    }
  };

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

  function getBlankPurchaseOrder(): TngPoInListing {
    return {
      id: 0,
      amount: 0.0,
      customerId: null,
      dateIn: dayjs(Date.now()),
      nameText: ''
    };
  };

  const handleRowDoubleClickEvent: GridEventListener<'rowDoubleClick'> = (
    params, // GridRowParams
    event, // MuiEvent<React.MouseEvent<HTMLElement>>
    details, // GridCallbackDetails
  ) => {
    setSelectedPurchaseOrder(params.row.id);
    setAddEditDialogOpen(true);
  };

  return (
    <Container>
      <h1>Purchase Orders</h1>
      <Stack style={{ width: '100%' }} alignItems="flex-start" spacing={2}>
        <div style={{ height: '500px', width: '100%' }}>
          <DataGrid
            onRowDoubleClick={handleRowDoubleClickEvent}
            autoPageSize
            rows={purchaseOrders}
            columns={columns}
          />
        </div>
        <Button type="button" variant="contained" color="primary" onClick={handleAddClicked}>Add...</Button>
        { addEditDialogOpen ?
          <AddEditPurchaseOrder open={addEditDialogOpen} handleClose={handleAddEditDialogClose}
            customers={customers} units={units}
            purchaseOrder={purchaseOrders.find(x => x.id === selectedPurchaseOrder) || getBlankPurchaseOrder()} />
          : null 
        }
    </Stack>
    </Container>);
};

export default PurchaseOrders;