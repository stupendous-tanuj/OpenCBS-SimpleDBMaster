﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCBS.GUI.UserControl;


using System.IO;

using OpenCBS.CoreDomain.Products;
using OpenCBS.Enums;
using OpenCBS.ExceptionsHandler;
using OpenCBS.Services;
using System.Security.Permissions;
using OpenCBS.MultiLanguageRessources;
using OpenCBS.Shared.Settings;



namespace OpenCBS.GUI.FixedAssetRegister
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class FrmAvailableFixedAssets : Form
    {
        private int _idPackage;
        private LoanProduct _package;
        public FrmAvailableFixedAssets()
        {
            
            InitializeComponent();
            _package = new LoanProduct();
            InitializeFixedDepositProductList(false);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int PackageFormId
        {
            set { _idPackage = value; }
            get { return _idPackage; }
        }
        private bool _showDeletedPackage = false;
        private void InitializeFixedDepositProductList(bool showAsDeleted)
        {
            lvFixedAsset.Items.Clear();
            FixedDepositProductService _fixedDepositProductService = ServicesProvider.GetInstance().GetFixedDepositProductService();
            List<IFixedDepositProduct> fixedDepositProductList = _fixedDepositProductService.FetchProduct(showAsDeleted);
            if (fixedDepositProductList != null)
            {
                foreach (FixedDepositProduct fixedDepositProduct in fixedDepositProductList)
                {
                    string deleted = "";
                    if(fixedDepositProduct.Delete == 0)
                        deleted = "Active";
                    else
                           deleted = "Deleted";
                    var item = new ListViewItem(new[] {
                    fixedDepositProduct.Id.ToString(),
                    deleted,
                    fixedDepositProduct.Name,
                    fixedDepositProduct.Code,                    
		            fixedDepositProduct.ClientType,
                    fixedDepositProduct.Currency.Name.ToString()


                    
                });
                    lvFixedAsset.Items.Add(item);

                }

                //lvFixedDepositProducts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

          
        }

        private string _CreateHtmlForShowingPackage(LoanProduct pPackage)
        {
           

            return "text";
        }

        private void buttonAddProduct_Click(object sender, System.EventArgs e)
        {
            AddFixedAsset _frmAddFixedAsset = new AddFixedAsset();
            _frmAddFixedAsset.Show();
        }

        private void buttonEditProduct_Click(object sender, System.EventArgs e)
        {
            try{
            int i = lvFixedAsset.SelectedIndices[0];
            string selectedFixedAssetId = lvFixedAsset.Items[i].Text;

            AddFixedAsset _frmAddFixedAsset = new AddFixedAsset(selectedFixedAssetId, true);
            _frmAddFixedAsset.Show();

            }
            catch (Exception ex)
            {
                try
                {

                    throw new OpenCbsFixedDepositException(OpenCbsFixedDepositExceptionEnum.FixedDepositProductSelectAProduct);
                }
                catch (Exception exc)
                {
                    new frmShowError(CustomExceptionHandler.ShowExceptionText(exc)).ShowDialog();
                }
            }
        }

        private void checkBoxShowDeletedProduct_CheckedChanged(object sender, System.EventArgs e)
        {
            if(checkBoxShowDeletedProduct.Checked == true)
                InitializeFixedDepositProductList(true);
            else
                InitializeFixedDepositProductList(false);
        }

        private void lvFixedDepositProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            try{
            int i = lvFixedAsset.SelectedIndices[0];
            string selectedFixedAssetId = lvFixedAsset.Items[i].Text;

            FixedDepositProductService _fixedDepositProductService = ServicesProvider.GetInstance().GetFixedDepositProductService();
            _fixedDepositProductService.DeleteFixedDepositProduct(Convert.ToInt32(selectedFixedAssetId));
            MessageBox.Show("Fixed Deposit Product Successfully Deleted.");


            }
            catch (Exception ex)
            {
                try
                {

                    throw new OpenCbsFixedDepositException(OpenCbsFixedDepositExceptionEnum.FixedDepositProductSelectAProduct);
                }
                catch (Exception exc)
                {
                    new frmShowError(CustomExceptionHandler.ShowExceptionText(exc)).ShowDialog();
                }
            }
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            try{
            int i = lvFixedAsset.SelectedIndices[0];
            string selectedProductId = lvFixedAsset.Items[i].Text;

            AddFixedAsset _frmAddFixedAsset = new AddFixedAsset(selectedProductId, false);
            _frmAddFixedAsset.Show();

            }
            catch (Exception ex)
            {
                try
                {

                    throw new OpenCbsFixedDepositException(OpenCbsFixedDepositExceptionEnum.FixedDepositProductSelectAProduct);
                }
                catch (Exception exc)
                {
                    new frmShowError(CustomExceptionHandler.ShowExceptionText(exc)).ShowDialog();
                }
            }
        }

        private void lvFixedDepositProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

    }
}