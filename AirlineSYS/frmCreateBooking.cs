﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineSYS
{
    public partial class frmCreateBooking : Form
    {
        frmAirlineMainMenu parent;
        public frmCreateBooking()
        {
            InitializeComponent();
        }
        public frmCreateBooking(frmAirlineMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnAirportConfirm_Click(object sender, EventArgs e)
        {

            DateTime departureDate = dtpDeptDate.Value.Date;
            DateTime returnDate = dtpReturnDate.Value.Date;

            if (cboDeptAirportBooking.Text.Equals("") || cboArrAirportBooking.Text.Equals("") || dtpDeptDate.Text.Equals("") ||
                dtpReturnDate.Text.Equals("") || txtNumBaggage.Text.Equals("") || txtForeName.Text.Equals("") || txtSurname.Text.Equals("") ||
                dtpDOB.Text.Equals("") || txtCreateBookingEmail.Text.Equals("") || txtCreateBooingPhone.Text.Equals("") || txtCreateBookingEircode.Text.Equals("") ||
                txtCardName.Text.Equals("") || txtCardNumber.Text.Equals("") || dtpExpireEndsCreateBooking.Text.Equals("") ||
                txtCreateBookingEircode.Text.Equals(""))
            {
                MessageBox.Show("All fields must be entered", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDeptAirportBooking.Focus();

                return;
            }

            else if (cboDeptAirportBooking.Text.Equals(cboArrAirportBooking.Text) || cboArrAirportBooking.Text.Equals(cboDeptAirportBooking.Text))
            {
                MessageBox.Show("Departure or Arrival Airports can not be the same", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDeptAirportBooking.SelectedIndex = -1;
                cboArrAirportBooking.SelectedIndex = -1;
                return;
            }

            else if (departureDate == returnDate)
            {
                MessageBox.Show("Departure date and return date must not be the same day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDeptDate.Focus();
                dtpReturnDate.Focus();
                return;
            }

            else if (!txtNumBaggage.Text.All(char.IsDigit))
            {
                MessageBox.Show("Number of baggage must be numberic", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumBaggage.Focus();
                return;
            }

            else if (txtCreateBookingEircode.Text.Length != 3 || !txtCreateBookingEircode.Text.All(char.IsUpper))
            {
                MessageBox.Show("Airport Code must be a valid THREE UPPERCASE LETTER Airport Code.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCreateBookingEircode.Focus();
                return;

            }

            else if (!(txtCreateBooingPhone.Text.StartsWith("08") || txtCreateBooingPhone.Text.StartsWith("+353")) || !(txtCreateBooingPhone.Text.Length > 0 && txtCreateBooingPhone.Text.Length <= 15) || !txtCreateBooingPhone.Text.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Airport phone must be Numeric, Starts with (08 or +353 ) and Maxium 15 characters", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCreateBooingPhone.Focus();
                return;
            }

            else if (!(txtCardName.Text.All(char.IsUpper) && txtCardName.Text.Length > 25) || !txtCardName.Text.All(char.IsLetter) )
            {
                MessageBox.Show("Card Name must be a number and MAXIMUM 25 letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCardName.Focus();
                return;
            }
            else if (txtCardNumber.Text.Length != 16 || txtCardNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show("Card number must be a numeric and length of 16", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCardNumber.Focus();
                return;
            }

            else if (dtpExpireEndsCreateBooking.Value.Year <= DateTime.Now.Year)
            {
                MessageBox.Show("Card expiration year must be greater than the current year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpExpireEndsCreateBooking.Focus();
                return;
            }
            else if (txtCVC.Text.Length != 3 || !txtCVC.Text.All(char.IsDigit))
            {
                MessageBox.Show("Card CVC must be length of 3 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCVC.Focus();
                return;
            }
            else if (txtCreateBookingEmail.Text.All(char.IsDigit) || txtCreateBookingEmail.Text.Length > 45)
            {
                MessageBox.Show("Airport Email must can not be Numeric and MAXIMUM length of 45", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCreateBookingEmail.Focus();
                return;
            }


            string email = txtCreateBookingEmail.Text;

            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Invalid email format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCreateBookingEmail.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Flight has been booked", "Success !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumBaggage.Clear();
                txtForeName.Clear();
                txtSurname.Clear();
                dtpDOB.Text = "";
                txtCreateBookingEmail.Clear();
                txtCreateBooingPhone.Clear();
                txtCreateBookingEircode.Clear();
                txtCardName.Clear();
                txtCardNumber.Clear();
                dtpExpireEndsCreateBooking.Text = "";
                cboDeptAirportBooking.Text = "";
                cboArrAirportBooking.Text = "";
            
            }


        }

        private void munBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAirlineMainMenu frmAirlineMainMenu = new frmAirlineMainMenu();
            frmAirlineMainMenu.Show();
        }



    }
}
