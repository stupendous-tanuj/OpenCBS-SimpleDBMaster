﻿// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.CoreDomain.Products;
using OpenCBS.Enums;
using OpenCBS.ExceptionsHandler;
using OpenCBS.GUI.UserControl;
using OpenCBS.MultiLanguageRessources;
using OpenCBS.Services;
using OpenCBS.Shared;
using OpenCBS.GUI.Tools;
using System.Globalization;

namespace OpenCBS.GUI.Products
{
    public partial class FrmAddCurrentAccountProduct : SweetBaseForm
    {
        CurrentAccountProduct _currentAccountProduct = null;
        CurrentAccountTransactionFees _currentAccountTransactionFees = null;

        public FrmAddCurrentAccountProduct()
        {
           
            InitializeComponent();
            InitializeComboBoxCurrencies();
            InitializeManagementFeeFrequency();
            InitializeTransactionType();
            tabControlSaving.TabPages.Remove(tabPageTransactions);
            btnUpdateTran.Visible = false;
           
        }

        void InitializeTransactionType()
        {
            cbTransactionType.Items.Clear();
            cbTransactionType.Items.Add(OCurrentAccount.SelectPaymentMethodDefault);
            cbTransactionType.Items.Add(OCurrentAccount.PaymentMethodCash);
            cbTransactionType.Items.Add(OCurrentAccount.PaymentMethodCheque);
            cbTransactionType.Items.Add(OCurrentAccount.PaymentMethodTransfer);
            cbTransactionType.SelectedIndex = 0;
            


        }

        void InitializeManagementFeeFrequency()
        {
            cbManagementFeeFreq.Items.Clear();
            cbManagementFeeFreq.Items.Add(OCurrentAccount.SelectFrequencyDefault);
            cbManagementFeeFreq.Items.Add(OCurrentAccount.FeeTypeMonthly);
            cbManagementFeeFreq.Items.Add(OCurrentAccount.FeeTypeQuarterly);
            cbManagementFeeFreq.Items.Add(OCurrentAccount.FeeTypeHalfYearly);
            cbManagementFeeFreq.Items.Add(OCurrentAccount.FeeTypeYearly);
            cbManagementFeeFreq.SelectedIndex = 0;

        }

        public FrmAddCurrentAccountProduct(int productId,bool enabled)
        {
            InitializeComponent();
            InitializeComboBoxCurrencies();
            InitializeManagementFeeFrequency();
            InitializeTransactionType();

            
           
            if (enabled == true)
            {
                btnUpdate.Visible = true;
                btnCurrentAccountProduct.Visible = false;
                btnUpdateTran.Visible = true;
               
            }
            else
            {
                btnUpdateTran.Visible = false;
                btnSaveTranFee.Visible = false;
            }

              CurrentAccountProductService _currentAccountProductService = ServicesProvider.GetInstance().GetCurrentAccountProductService();
              _currentAccountProduct = _currentAccountProductService.FetchProduct(productId);


          
            cbCurrency.SelectedItem = _currentAccountProduct.Currency.Name;
            bool clientTypeCorp = clientTypeCorpCheckBox.Checked;
            bool clientTypeIndiv = clientTypeIndivCheckBox.Checked;
            bool clientTypeVillage = clientTypeVillageCheckBox.Checked;
            bool clientTypeGroup = clientTypeGroupCheckBox.Checked;
            bool clientTypeAll = clientTypeAllCheckBox.Checked;
            tbCodeCurrentAccountProduct.Text = _currentAccountProduct.CurrentAccountProductCode;
            tbName.Text = _currentAccountProduct.CurrentAccountProductName;
            

            if(_currentAccountProduct.EntryFeesType == OCurrentAccount.FeeTypeFlat)
            {
               rbFlatEntryFees.Checked = true;

            }
            else
            {
               rbRateEntryFees.Checked = false;
   
            }

            if(_currentAccountProduct.ReopenFeesType == OCurrentAccount.FeeTypeFlat)
            {
               rbFlatReopenFees.Checked = true;
            }
            else
            {
               rbRateReopenFees.Checked = true;

            }

            if(_currentAccountProduct.ClosingFeesType == OCurrentAccount.FeeTypeFlat)
            {
            rbFlatCloseFees.Checked = true;
            }
            else
            {
            rbFlatCloseFees.Checked = true;
            }

            if(_currentAccountProduct.ManagementFeesType == OCurrentAccount.FeeTypeFlat)
            {
               rbFlatManagementFees.Checked = true ;
            }
            else
            {
               rbRateManagementFees.Checked = true ;
            }

            if(_currentAccountProduct.OverdraftType == OCurrentAccount.FeeTypeFlat)
            {
            rbFlatOverdraftFees.Checked = true;
            }
            else
            {
            rbRateOverdraftFees.Checked = true;
            }
            cbManagementFeeFreq.SelectedItem = _currentAccountProduct.ManagementFeesFrequency;
            tbInitialAmountMin.Text = _currentAccountProduct.InitialAmountMin.GetFormatedValue(true);
            tbInitialAmountMax.Text = _currentAccountProduct.InitialAmountMax.GetFormatedValue(true);

            tbBalanceMin.Text = _currentAccountProduct.BalanceMin.GetFormatedValue(true);
            tbBalanceMax.Text = _currentAccountProduct.BalanceMax.GetFormatedValue(true);

            if (_currentAccountProduct.EntryFeesValue.HasValue)
                tbEntryFees.Text = _currentAccountProduct.EntryFeesValue.GetFormatedValue(true);
            else
            {
                tbEntryFeesMin.Text = _currentAccountProduct.EntryFeesMin.GetFormatedValue(true);
                tbEntryFeesMax.Text = _currentAccountProduct.EntryFeesMax.GetFormatedValue(true);
            }

            if (_currentAccountProduct.ReopenFeesValue.HasValue)
                tbReopenFees.Text = _currentAccountProduct.ReopenFeesValue.GetFormatedValue(true);
            else
            {
                tbReopenFeesMax.Text = _currentAccountProduct.ReopenFeesMax.GetFormatedValue(true);
                tbReopenFeesMin.Text = _currentAccountProduct.ReopenFeesMin.GetFormatedValue(true);
            }

            if (_currentAccountProduct.ClosingFeesValue.HasValue)
                tbCloseFees.Text = _currentAccountProduct.ClosingFeesValue.GetFormatedValue(true);
            else
            {
                tbCloseFeesMin.Text = _currentAccountProduct.ClosingFeesMin.GetFormatedValue(true);
                tbCloseFeesMax.Text = _currentAccountProduct.ClosingFeesMax.GetFormatedValue(true);
            }

            if (_currentAccountProduct.ManagementFeesValue.HasValue)
                tbManagementFees.Text = _currentAccountProduct.ManagementFeesValue.GetFormatedValue(true);
            else
            {
                tbManagementFeesMin.Text = _currentAccountProduct.ManagementFeesMin.GetFormatedValue(true);
                tbManagementFeesMax.Text = _currentAccountProduct.ManagementFeesMax.GetFormatedValue(true);
            }


            if (_currentAccountProduct.OverdraftValue.HasValue)
                tbOverdraftFees.Text = _currentAccountProduct.OverdraftValue.GetFormatedValue(true);
            else
            {
                tbOverdraftFeesMin.Text = _currentAccountProduct.OverdraftMin.GetFormatedValue(true);
                tbOverdraftFeesMax.Text = _currentAccountProduct.OverdraftMax.GetFormatedValue(true);
            }

            if (_currentAccountProduct.InterestValue.HasValue)
                tbInterestValue.Text = _currentAccountProduct.InterestValue.ToString();
            else
            {
                tbInterestRateMin.Text = _currentAccountProduct.InterestMin.ToString();
                tbInterestRateMax.Text = _currentAccountProduct.InterestMax.ToString();
            }
            

            tbInterestCalculationFrequency.Text = _currentAccountProduct.InterestFrequency.ToString();
            

            string[] clientType = _currentAccountProduct.ClientType.Split(',');

            if (clientType[0] == OClientTypes.All+"")
                clientTypeAllCheckBox.Checked = true;
            else
            {
                for (int i = 0; i < clientType.Length; i++)
                {
                    if (clientType[i] == OClientTypes.Corporate + "")
                        clientTypeCorpCheckBox.Checked = true;
                    if (clientType[i] == OClientTypes.Person + "")
                        clientTypeIndivCheckBox.Checked = true;
                    if (clientType[i] == OClientTypes.Village + "")
                        clientTypeVillageCheckBox.Checked = true;
                    if (clientType[i] == OClientTypes.Group + "")
                        clientTypeGroupCheckBox.Checked = true;
                }

            }

            if (_currentAccountProduct.InterestType == OCurrentAccount.FeeTypeFlat)
            {
                rbODInterestFlat.Checked = true;
            }
            else
            {
                rbODInterestRate.Checked = true;
            }

            

            if (_currentAccountProduct.CommitmentFeeType == OCurrentAccount.FeeTypeFlat)
            {
                rbODCommitmentFlat.Checked = true;
            }
            else
            {
                rbODCommitmentRate.Checked = true;
            }

            if (_currentAccountProduct.CommitmentFeeType == OCurrentAccount.FeeTypeFlat)
            {
                rbODCommitmentFlat.Checked = true;
            }
            else
            {
                rbODCommitmentRate.Checked = true;
            }

            if (_currentAccountProduct.OverdraftInterestValue.HasValue)
                tbODInterestValue.Text = _currentAccountProduct.OverdraftInterestValue.ToString();
            else
            {
                tbODInterestMin.Text = _currentAccountProduct.OverdraftInterestMin.ToString();
                tbODInterestMax.Text = _currentAccountProduct.OverdraftInterestMax.ToString();
            }
            if (_currentAccountProduct.CommitmentFeeValue.HasValue)
                tbODCommitmentValue.Text = _currentAccountProduct.CommitmentFeeValue.ToString();
            else
            {
                tbODCommitmentMin.Text = _currentAccountProduct.CommitmentFeeMin.ToString();
                tbODCommitmentMax.Text = _currentAccountProduct.CommitmentFeeMax.ToString();
            }
            if (_currentAccountProduct.OverdraftValue.HasValue)
                tbODLimitValue.Text = _currentAccountProduct.OverdraftValue.GetFormatedValue(true);
            else
            {
                tbODLimitMin.Text = _currentAccountProduct.OverdraftLimitMin.GetFormatedValue(true);
                tbODLimitMax.Text = _currentAccountProduct.OverdraftLimitMax.GetFormatedValue(true);
            }
            


            CurrentAccountControl(enabled);
            tbCodeCurrentAccountProduct.Enabled = false;
            tbName.Enabled = false;

            cbTransactionType.Enabled = true;
            rbCredit.Enabled = true;
            rbDebit.Enabled = true;

        }

            void CurrentAccountControl(bool enabled)
            {
            cbCurrency.Enabled = enabled;
            clientTypeCorpCheckBox.Enabled = enabled;
            clientTypeIndivCheckBox.Enabled = enabled;
            clientTypeVillageCheckBox.Enabled = enabled;
            clientTypeGroupCheckBox.Enabled = enabled;
            clientTypeAllCheckBox.Enabled = enabled;
            tbCodeCurrentAccountProduct.Enabled = enabled;
            tbName.Enabled = enabled;
            rbFlatEntryFees.Enabled = enabled;
            rbRateEntryFees.Enabled = enabled;
            rbFlatReopenFees.Enabled = enabled;
            rbRateReopenFees.Enabled = enabled;
            rbFlatCloseFees.Enabled = enabled;
            rbRateCloseFees.Enabled = enabled;
            rbFlatManagementFees.Enabled = enabled;
            rbRateManagementFees.Enabled = enabled;
            rbFlatOverdraftFees.Enabled = enabled;
            rbRateOverdraftFees.Enabled = enabled;
            cbManagementFeeFreq.Enabled = enabled;
            tbInitialAmountMin.Enabled = enabled;
            tbInitialAmountMax.Enabled = enabled;
            tbBalanceMin.Enabled = enabled;
            tbBalanceMax.Enabled = enabled;
            tbEntryFeesMin.Enabled = enabled;
            tbEntryFeesMax.Enabled = enabled;
            tbReopenFeesMin.Enabled = enabled;
            tbReopenFeesMax.Enabled = enabled;
            tbCloseFeesMin.Enabled = enabled;
            tbCloseFeesMax.Enabled = enabled;
            tbManagementFeesMin.Enabled = enabled;
            tbManagementFeesMax.Enabled = enabled;
            tbOverdraftFeesMin.Enabled = enabled;
            tbOverdraftFeesMax.Enabled = enabled;
            tbEntryFees.Enabled = enabled;
            tbReopenFees.Enabled = enabled;
            tbCloseFees.Enabled = enabled;
            tbManagementFees.Enabled = enabled;
            tbOverdraftFees.Enabled = enabled;

            tbInterestRateMin.Enabled = enabled;
            tbInterestRateMax.Enabled = enabled;
            tbInterestValue.Enabled = enabled;
            tbInterestCalculationFrequency.Enabled = enabled;
            tbODLimitValue.Enabled = enabled;

            cbTransactionType.Enabled = enabled;
            rbTranFeeFlat.Enabled = enabled;
            rbTranFeeRate.Enabled = enabled;
            tbTranFeeValue.Enabled = enabled;
            tbTranFeeMin.Enabled = enabled;
            tbTranFeeMax.Enabled = enabled;
            
            btnSaveTranFee.Enabled = enabled;
            rbCredit.Enabled = enabled;
            rbDebit.Enabled = enabled;



            rbODInterestFlat.Enabled = enabled;
            rbODInterestRate.Enabled = enabled;
            tbODInterestMin.Enabled = enabled;
            tbODInterestMax.Enabled = enabled;
            tbODInterestValue.Enabled = enabled;
            rbODCommitmentFlat.Enabled = enabled;
            rbODCommitmentRate.Enabled = enabled;
            tbODCommitmentMin.Enabled = enabled;
            tbODCommitmentMax.Enabled = enabled;
            tbODCommitmentValue.Enabled = enabled;
            tbODLimitMin.Enabled = enabled;
            tbODLimitMax.Enabled = enabled;
            tbODLimitValue.Enabled = enabled;



            }


        private void InitializeComboBoxCurrencies()
        {
            cbCurrency.Items.Clear();
            cbCurrency.Text = MultiLanguageStrings.GetString(Ressource.FrmAddLoanProduct, "Currency.Text");
            List<Currency> currencies = ServicesProvider.GetInstance().GetCurrencyServices().FindAllCurrencies();
            Currency line = new Currency { Name = MultiLanguageStrings.GetString(Ressource.FrmAddLoanProduct, "Currency.Text"), Id = 0 };
            cbCurrency.Items.Add(line);

            foreach (Currency cur in currencies)
            {
                cbCurrency.Items.Add(cur.Name);
            }



            bool oneCurrency = 2 == cbCurrency.Items.Count;
            cbCurrency.SelectedIndex = oneCurrency ? 1 : 0;
            cbCurrency.Enabled = !oneCurrency;
        }

        void InitializeCurrentAccountProduct()
        {
            
            bool clientTypeCorp = clientTypeCorpCheckBox.Checked;
            bool clientTypeIndiv = clientTypeIndivCheckBox.Checked;
            bool clientTypeVillage = clientTypeVillageCheckBox.Checked;
            bool clientTypeGroup = clientTypeGroupCheckBox.Checked;
            bool clientTypeAll = clientTypeAllCheckBox.Checked;
            string CodeFixedDepositProduct ="";
            if (_currentAccountProduct.Id != 0)
                CodeFixedDepositProduct = tbCodeCurrentAccountProduct.Text;
            else
                CodeFixedDepositProduct = tbCodeCurrentAccountProduct.Text + "-CA";
            string Name = tbName.Text;

            string clientType = "";

            if (clientTypeAll == true)
                clientType = OClientTypes.All + "";
            else
            {
                if (clientTypeCorp == true)
                    clientType = clientType + OClientTypes.Corporate + " ";
                if (clientTypeIndiv == true)
                    clientType = clientType + OClientTypes.Person + " ";
                if (clientTypeVillage == true)
                    clientType = clientType + OClientTypes.Village + " ";
                if (clientTypeGroup == true)
                    clientType = clientType + OClientTypes.Group + " ";

                if (clientType.Length > 0)
                clientType = clientType.Substring(0, clientType.Length);
            }



            if (rbFlatEntryFees.Checked)
            {
                _currentAccountProduct.EntryFeesType = OCurrentAccount.FeeTypeFlat;
            }
            else
            {
                _currentAccountProduct.EntryFeesType = OCurrentAccount.FeeTypeRate;
            }
            if (rbFlatReopenFees.Checked)
            {
                _currentAccountProduct.ReopenFeesType = OCurrentAccount.FeeTypeFlat;
            }
            else
            {
                _currentAccountProduct.ReopenFeesType = OCurrentAccount.FeeTypeRate;
            }
            if (rbFlatCloseFees.Checked)
            {
                _currentAccountProduct.ClosingFeesType = OCurrentAccount.FeeTypeFlat;
            }
            else
            {
                _currentAccountProduct.ClosingFeesType = OCurrentAccount.FeeTypeRate;
            }
            if (rbFlatManagementFees.Checked)
            {
                _currentAccountProduct.ManagementFeesType = OCurrentAccount.FeeTypeFlat;
            }
            else
            {
                _currentAccountProduct.ManagementFeesType = OCurrentAccount.FeeTypeRate;
            }
            if (rbFlatOverdraftFees.Checked)
            {
                _currentAccountProduct.OverdraftType = OCurrentAccount.FeeTypeFlat;
            }
            else
            {
                _currentAccountProduct.OverdraftType = OCurrentAccount.FeeTypeRate;
            }
            decimal? InitialAmountMin = ServicesHelper.ConvertStringToNullableDecimal(tbInitialAmountMin.Text);
            decimal? InitialAmountMax = ServicesHelper.ConvertStringToNullableDecimal(tbInitialAmountMax.Text);
            decimal? BalanceMin = ServicesHelper.ConvertStringToNullableDecimal(tbBalanceMin.Text);
            decimal? BalanceMax = ServicesHelper.ConvertStringToNullableDecimal(tbBalanceMax.Text);


            decimal? EntryFeesMin = ServicesHelper.ConvertStringToNullableDecimal(tbEntryFeesMin.Text);
            decimal? EntryFeesMax = ServicesHelper.ConvertStringToNullableDecimal(tbEntryFeesMax.Text);
            decimal? ReopenFeesMin = ServicesHelper.ConvertStringToNullableDecimal(tbReopenFeesMin.Text);
            decimal? ReopenFeesMax = ServicesHelper.ConvertStringToNullableDecimal(tbReopenFeesMax.Text);
            decimal? CloseFeesMin = ServicesHelper.ConvertStringToNullableDecimal(tbCloseFeesMin.Text);
            decimal? CloseFeesMax = ServicesHelper.ConvertStringToNullableDecimal(tbCloseFeesMax.Text);
            decimal? ManagementFeesMin = ServicesHelper.ConvertStringToNullableDecimal(tbManagementFeesMin.Text);
            decimal? ManagementFeesMax = ServicesHelper.ConvertStringToNullableDecimal(tbManagementFeesMax.Text);
            decimal? OverdraftFeesMin = ServicesHelper.ConvertStringToNullableDecimal(tbOverdraftFeesMin.Text);
            decimal? OverdraftFeesMax = ServicesHelper.ConvertStringToNullableDecimal(tbOverdraftFeesMax.Text);
            decimal? EntryFees = ServicesHelper.ConvertStringToNullableDecimal(tbEntryFees.Text);
            decimal? ReopenFees = ServicesHelper.ConvertStringToNullableDecimal(tbReopenFees.Text);
            decimal? CloseFees = ServicesHelper.ConvertStringToNullableDecimal(tbCloseFees.Text);
            decimal? ManagementFees = ServicesHelper.ConvertStringToNullableDecimal(tbManagementFees.Text);
            decimal? OverdraftFees = ServicesHelper.ConvertStringToNullableDecimal(tbOverdraftFees.Text);


            _currentAccountProduct.ManagementFeesFrequency = cbManagementFeeFreq.SelectedItem.ToString();
            _currentAccountProduct.CurrentAccountProductName = Name;
            _currentAccountProduct.CurrentAccountProductCode = CodeFixedDepositProduct;
            _currentAccountProduct.ClientType = clientType;

            List<Currency> currencies = ServicesProvider.GetInstance().GetCurrencyServices().FindAllCurrencies();
            foreach (Currency cur in currencies)
            {
                if ((cbCurrency.SelectedItem.ToString() == cur.Name) && (cbCurrency.SelectedItem.ToString() != OCurrentAccount.SelectCurrencyDefault))
                    _currentAccountProduct.Currency = cur;
                
            }


             
            _currentAccountProduct.InitialAmountMin = InitialAmountMin;
            _currentAccountProduct.InitialAmountMax = InitialAmountMax;
            _currentAccountProduct.BalanceMin = BalanceMin;
            _currentAccountProduct.BalanceMax = BalanceMax;
            _currentAccountProduct.EntryFeesMin = EntryFeesMin;
            _currentAccountProduct.EntryFeesMax = EntryFeesMax;
            _currentAccountProduct.ReopenFeesMin = ReopenFeesMin;
            _currentAccountProduct.ReopenFeesMax = ReopenFeesMax;
            _currentAccountProduct.ClosingFeesMin = CloseFeesMin;
            _currentAccountProduct.ClosingFeesMax = CloseFeesMax;
            _currentAccountProduct.ManagementFeesMin = ManagementFeesMin;
            _currentAccountProduct.ManagementFeesMax = ManagementFeesMax;
            _currentAccountProduct.OverdraftMin = OverdraftFeesMin;
            _currentAccountProduct.OverdraftMax = OverdraftFeesMax;
            _currentAccountProduct.EntryFeesValue = EntryFees;
            _currentAccountProduct.ReopenFeesValue = ReopenFees;
            _currentAccountProduct.ClosingFeesValue = CloseFees;
            _currentAccountProduct.ManagementFeesValue = ManagementFees;
            _currentAccountProduct.OverdraftValue = OverdraftFees;
            _currentAccountProduct.Delete = 0;

            _currentAccountProduct.InterestMin = ServicesHelper.ConvertStringToNullableDouble(tbInterestRateMin.Text, false);
            _currentAccountProduct.InterestMax = ServicesHelper.ConvertStringToNullableDouble(tbInterestRateMax.Text, false);
            _currentAccountProduct.InterestValue = ServicesHelper.ConvertStringToNullableDouble(tbInterestValue.Text, false);
            _currentAccountProduct.InterestFrequency = ServicesHelper.ConvertStringToNullableInt32(tbInterestCalculationFrequency.Text);
            
            _currentAccountProduct.InterestType = OCurrentAccount.FeeTypeRate;

            
            if (rbODInterestFlat.Checked)
            {
                _currentAccountProduct.OverdraftInterestType = OCurrentAccount.FeeTypeFlat;
            }
            else
            {
                _currentAccountProduct.OverdraftInterestType = OCurrentAccount.FeeTypeRate;
            }
            
            

            _currentAccountProduct.OverdraftInterestMin = ServicesHelper.ConvertStringToNullableDouble(tbODInterestMin.Text, false);
            _currentAccountProduct.OverdraftInterestMax = ServicesHelper.ConvertStringToNullableDouble(tbODInterestMax.Text, false);
            _currentAccountProduct.OverdraftInterestValue = ServicesHelper.ConvertStringToNullableDouble(tbODInterestValue.Text, false);

            if (rbODCommitmentFlat.Checked)
            {
                _currentAccountProduct.CommitmentFeeType = OCurrentAccount.FeeTypeFlat;
            }
            else
            {
                _currentAccountProduct.CommitmentFeeType = OCurrentAccount.FeeTypeRate;
            }

            _currentAccountProduct.CommitmentFeeMin = ServicesHelper.ConvertStringToNullableDouble(tbODCommitmentMin.Text, false);
            _currentAccountProduct.CommitmentFeeMax = ServicesHelper.ConvertStringToNullableDouble(tbODCommitmentMax.Text, false);
            _currentAccountProduct.CommitmentFeeValue = ServicesHelper.ConvertStringToNullableDouble(tbODCommitmentValue.Text, false);

            _currentAccountProduct.OverdraftLimitMin = ServicesHelper.ConvertStringToNullableDecimal(tbODLimitMin.Text);

            _currentAccountProduct.OverdraftLimitMax = ServicesHelper.ConvertStringToNullableDecimal(tbODLimitMax.Text);
            _currentAccountProduct.OverdraftLimit = ServicesHelper.ConvertStringToNullableDecimal(tbODLimitValue.Text);

        }


        private void btSavingProduct_Click(object sender, EventArgs e)
        {

            try
            {
                _currentAccountProduct = new CurrentAccountProduct();

                InitializeCurrentAccountProduct();

                CurrentAccountProductService _currentAccountProductService = ServicesProvider.GetInstance().GetCurrentAccountProductService();
                int ret = _currentAccountProductService.SaveCurrentAccountProduct(_currentAccountProduct);

                if (ret >= 1)
                    MessageBox.Show(MultiLanguageStrings.GetString(Ressource.FrmAddCurrentAccountProduct, "Current Account Product Success.Text"));
                

                tabControlSaving.TabPages.Remove(tabPageTransactions);
                tabControlSaving.TabPages.Add(tabPageTransactions);
                tabControlSaving.SelectedTab = tabPageTransactions;

                _currentAccountTransactionFees = new CurrentAccountTransactionFees();
                _currentAccountTransactionFees.CurrentAccountProductId = ret;

                FrmAvailableCurrentAccountProducts frmAvailableCurrentAccountProducts = (FrmAvailableCurrentAccountProducts)Application.OpenForms["FrmAvailableCurrentAccountProducts"];
                frmAvailableCurrentAccountProducts.InitializeCurrentAccountProductList(false);

                btnCurrentAccountProduct.Enabled = false;
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }


        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clientTypeAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (clientTypeAllCheckBox.Checked == true)
            {
                clientTypeCorpCheckBox.Checked = true;
                clientTypeIndivCheckBox.Checked = true;
                clientTypeVillageCheckBox.Checked = true;
                clientTypeGroupCheckBox.Checked = true;
                clientTypeCorpCheckBox.Enabled = false;
                clientTypeIndivCheckBox.Enabled = false;
                clientTypeVillageCheckBox.Enabled = false;
                clientTypeGroupCheckBox.Enabled = false;
            }
            else
            {
                clientTypeCorpCheckBox.Checked = false;
                clientTypeIndivCheckBox.Checked = false;
                clientTypeVillageCheckBox.Checked = false;
                clientTypeGroupCheckBox.Checked = false;

                clientTypeCorpCheckBox.Enabled = true;
                clientTypeIndivCheckBox.Enabled = true;
                clientTypeVillageCheckBox.Enabled = true;
                clientTypeGroupCheckBox.Enabled = true;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try{
            InitializeCurrentAccountProduct();

            CurrentAccountProductService _currentAccountProductService = ServicesProvider.GetInstance().GetCurrentAccountProductService();
            _currentAccountProductService.UpdateCurrentAccountProduct(_currentAccountProduct, _currentAccountProduct.Id);
            MessageBox.Show("Current Account Product Successfully Updated.");

            FrmAvailableCurrentAccountProducts frmAvailableCurrentAccountProducts = (FrmAvailableCurrentAccountProducts)Application.OpenForms["FrmAvailableCurrentAccountProducts"];
            frmAvailableCurrentAccountProducts.InitializeCurrentAccountProductList(false);

            btnUpdate.Enabled = false;

            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void InitializeCurrentAccountTransactionFees()
        {
            _currentAccountTransactionFees.CurrentAccountProductId = _currentAccountProduct.Id;
            
            _currentAccountTransactionFees.TransactionType = cbTransactionType.SelectedItem.ToString();
            if(rbTranFeeFlat.Checked == true)
            _currentAccountTransactionFees.TransactionFeesType = OCurrentAccount.FeeTypeFlat;
            else
                _currentAccountTransactionFees.TransactionFeesType = OCurrentAccount.FeeTypeRate;
            if(rbCredit.Checked == true)
                _currentAccountTransactionFees.TransactionMode = "Credit";
            else
                _currentAccountTransactionFees.TransactionMode = "Debit";
            _currentAccountTransactionFees.TransactionFees = ServicesHelper.ConvertStringToNullableDecimal(tbTranFeeValue.Text);
            _currentAccountTransactionFees.TransactionFeeMin = ServicesHelper.ConvertStringToNullableDecimal(tbTranFeeMin.Text);
            _currentAccountTransactionFees.TransactionFeeMax = ServicesHelper.ConvertStringToNullableDecimal(tbTranFeeMax.Text);
            
        }


        private void btnSaveTranFee_Click(object sender, EventArgs e)
        {
            try{
            InitializeCurrentAccountTransactionFees();


            CurrentAccountProductService _currentAccountProductService = ServicesProvider.GetInstance().GetCurrentAccountProductService();
            int ret = _currentAccountProductService.SaveCurrentAccountTransactionFees(_currentAccountTransactionFees);

            if (ret >= 1)
                MessageBox.Show("Transaction Fee Successfully Specified.");
            else if(ret == -1)
                MessageBox.Show("Transaction Fee Already Specified.");
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        


        void FetchTransactionFees()
        {
            string transactionType = cbTransactionType.SelectedItem.ToString();
            if (transactionType != OCurrentAccount.SelectPaymentMethodDefault)
            {
                string transactionMode = "";

                if (rbCredit.Checked == true)
                    transactionMode = "Credit";
                else
                    transactionMode = "Debit";



                CurrentAccountProductService _currentAccountProductService = ServicesProvider.GetInstance().GetCurrentAccountProductService();
                _currentAccountTransactionFees = _currentAccountProductService.FetchTransactionFee(transactionType, transactionMode, _currentAccountProduct.Id);

                if (_currentAccountTransactionFees != null)
                {
                    if (_currentAccountTransactionFees.TransactionFeesType == OCurrentAccount.FeeTypeFlat)
                        rbTranFeeFlat.Checked = true;
                    else
                        rbTranFeeRate.Checked = true;

                    tbTranFeeValue.Text = _currentAccountTransactionFees.TransactionFees.GetFormatedValue(true);
                    tbTranFeeMin.Text = _currentAccountTransactionFees.TransactionFeeMin.GetFormatedValue(true);

                    tbTranFeeMax.Text = _currentAccountTransactionFees.TransactionFeeMax.GetFormatedValue(true);
                    btnSaveTranFee.Visible = false;
                    btnUpdateTran.Visible = true;
                }
                else
                {
                    _currentAccountTransactionFees = new CurrentAccountTransactionFees();
                    tbTranFeeValue.Text = "";
                    tbTranFeeMin.Text = "";

                    tbTranFeeMax.Text = "";
                    btnSaveTranFee.Visible = true;
                    btnUpdateTran.Visible = false;

                }

            }
        }

        private void cbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

            FetchTransactionFees();

        }

        private void btnUpdateTran_Click(object sender, EventArgs e)
        {
          try{
            InitializeCurrentAccountTransactionFees();


            CurrentAccountProductService _currentAccountProductService = ServicesProvider.GetInstance().GetCurrentAccountProductService();
            _currentAccountProductService.UpdateCurrentAccountTransactionFees(_currentAccountTransactionFees, _currentAccountTransactionFees.TransactionFeesType, _currentAccountTransactionFees.TransactionMode, _currentAccountTransactionFees.CurrentAccountProductId);

           
                MessageBox.Show("Transaction Fee Successfully Updated.");
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }

        }

        private void tbInitialAmountMin_TextChanged(object sender, EventArgs e)
        {

        }


        void KeyPressControl(KeyPressEventArgs e)
        {
            int keyCode = e.KeyChar;

            if (
                (keyCode >= 48 && keyCode <= 57) ||
                (keyCode == 8) ||
                (Char.IsControl(e.KeyChar) && e.KeyChar != ((char)Keys.V | (char)Keys.ControlKey))
                ||
                (Char.IsControl(e.KeyChar) && e.KeyChar != ((char)Keys.C | (char)Keys.ControlKey))
                ||
                (e.KeyChar.ToString() == NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void tbInitialAmountMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbInitialAmountMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbBalanceMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbBalanceMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbInterestRateMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbInterestRateMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbInterestValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbInterestCalculationFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbOverdraftFeesMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbOverdraftFeesMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbOverdraftFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbOverdraftLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbEntryFeesMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void tbTranFeeValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbOverdraftFeesMin_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            KeyPressControl(e);
        }

        private void rbCredit_CheckedChanged(object sender, EventArgs e)
        {
            FetchTransactionFees();
        }

        private void rbDebit_CheckedChanged(object sender, EventArgs e)
        {
            FetchTransactionFees();
        }

       
    }
}
