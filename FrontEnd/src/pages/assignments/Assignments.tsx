import { Button, Container, FormControl, Grid, InputLabel, MenuItem, Select, Stack } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import dayjs from "dayjs";
import { useEffect, useState } from "react";
import { TngAssignmentListing } from "../../model/assignment-listing";
import AddEditAssignment from "./AddEditAssignment";

const API_ENDPOINT = 'https://localhost:7120';

const columns: GridColDef[] = [
  { field: 'id', headerName: 'ID', width: 7 },
  { field: 'nameText', headerName: 'Text', width: 120 },
  {
    field: 'dateIn', headerName: 'Date', width: 120, type: 'date', valueGetter: (params) => {
      if (!params.value) return null;
      return params.value.toDate();
    }
  },
  { field: 'customerName', headerName: 'Customer', width: 120 }
];


const Assignments: React.FC = () => {

  const [assignments, setAssignments] = useState<TngAssignmentListing[]>([]);
  const [addEditDialogOpen, setAddEditDialogOpen] = useState(false);
  const [height, setHeight] = useState(400);

  const handleAddEditDialogClose = () => {
    setAddEditDialogOpen(false);
  };

  const handleAddClicked = () => {
    setAddEditDialogOpen(true);
  };

  useEffect(() => {
    fetchAssignments();
  }, []);

  const fetchAssignments = async () => {
    try {
      const response = await fetch(`${API_ENDPOINT}/api/assignments?take=9999`);
      const data = await response.json();
      setAssignments(data.map((assignment: any) => {
        return {
          ...assignment,
          dateIn: assignment.dateIn ? dayjs(assignment.dateIn) : null
        };
      }));
    } catch (error) {
      console.error('Error fetching assignments:', error);
    }
  };

  return (
    <Container>
      <h1>Assignments</h1>
      <Stack style={{ width: '100%' }} alignItems="flex-start" spacing={2}>
        <div style={{ height: '500px', width: '100%' }}>
          <DataGrid
            autoPageSize
              rows={assignments}
              columns={columns}
            />
        </div>
        <Button type="button" variant="contained" color="primary" onClick={ handleAddClicked }>Add...</Button>
        <AddEditAssignment open={addEditDialogOpen} handleClose={ handleAddEditDialogClose } />
      </Stack>
    </Container>);
};

export default Assignments;