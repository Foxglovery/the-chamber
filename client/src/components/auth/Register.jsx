import React, { useState } from 'react';
import { TextField, Button, Container, Typography, Link } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { register } from '../../managers/authManager';

export default function Register({ setLoggedInUser }) {
  const [formState, setFormState] = useState({
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    address: '',
    password: '',
    confirmPassword: '',
  });
  const [passwordMismatch, setPasswordMismatch] = useState(false);
  const [registrationFailure, setRegistrationFailure] = useState(false);

  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormState(prevState => ({ ...prevState, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const { password, confirmPassword } = formState;

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      register(formState).then((user) => {
        if (user) {
          setLoggedInUser(user);
          navigate('/');
        } else {
          setRegistrationFailure(true);
        }
      });
    }
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h3" component="h1" gutterBottom>
        Sign Up
      </Typography>
      {Object.keys(formState).slice(0, -1).map((key) => (
        <TextField
          key={key}
          margin="normal"
          required
          fullWidth
          id={key}
          label={key.charAt(0).toUpperCase() + key.slice(1).replace(/([A-Z])/g, ' $1').trim()}
          name={key}
          autoComplete={key}
          type={key.includes('password') ? 'password' : 'text'}
          value={formState[key]}
          onChange={handleChange}
          error={passwordMismatch && key === 'confirmPassword'}
          helperText={passwordMismatch && key === 'confirmPassword' ? 'Passwords do not match!' : ''}
        />
      ))}
      {registrationFailure && <Typography color="error">Registration Failure</Typography>}
      <Button
        type="submit"
        fullWidth
        variant="contained"
        color="primary"
        sx={{ mt: 3, mb: 2 }}
        onClick={handleSubmit}
        disabled={passwordMismatch}
      >
        Register
      </Button>
      <Typography>
        Already signed up? Log in {' '}
        <Link href="/login" underline="hover">
          here
        </Link>
      </Typography>
    </Container>
  );
}
