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
          <Typography variant="h6" component={Link} to="/" sx={{ flexGrow: 1 }}>
            <Button color="inherit">
              Tengil
            </Button>
          </Typography>
        <Link to="/assignments">
            <Button color="inherit">
              Assignments
            </Button>
        </Link>
          <Link to="/purchase-orders">
            <Button color="inherit">
              Purchase Orders
            </Button>
          </Link>
          <Link to="/invoices">
            <Button color="inherit">
              Invoices
            </Button>
          </Link>
          <Link to="/customers">
            <Button color="inherit">
              Customers
            </Button>
          </Link>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default TopMenu;
