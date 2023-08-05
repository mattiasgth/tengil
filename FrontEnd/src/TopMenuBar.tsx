import React from 'react';
import { Link } from 'react-router-dom';
import { AppBar, Toolbar, Typography, Button, Box, IconButton } from '@mui/material';
import { styled } from '@mui/system';
import MenuIcon from '@mui/icons-material/Menu';

const TopMenu: React.FC = () => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" sx={{ flexGrow: 1 }}>
            <Button color="inherit" component={Link} to="/">
              Tengil
            </Button>
          </Typography>
          <Button component={Link} to="/assignments" color="inherit">
            Assignments
          </Button>
          <Button component={Link} to="/purchase-orders" color="inherit">
            Purchase Orders
          </Button>
          <Button component={Link} to="/invoices" color="inherit">
            Invoices
          </Button>
          <Button component={Link} to="/customers" color="inherit">
            Customers
          </Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default TopMenu;
