using CMSLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.DoctorSchadule
{
    public partial class ManageDoctorSchedule : Form
    {
        private int _DoctorID;
        private clsDoctor _Doctor;
        private DataTable _dtDoctorSchedules;
        public ManageDoctorSchedule(int doctorID)
        {
            InitializeComponent();
            _DoctorID = doctorID;
        }

        private void ResetAllControls()
        {
            cbxMonday.Checked = false;
            dtpMondayStartTime.Enabled = false;
            dtpMondayEndTime.Enabled = false;



            cbxTuesday.Checked = false;
            dtpTuesdayStartTime.Enabled = false;
            dtpTuesdayEndTime.Enabled = false;



            cbxWednesday.Checked = false;
            dtpWednesdayStartTime.Enabled = false;
            dtpWednesdayEndTime.Enabled = false;



            cbxThursday.Checked = false;
            dtpThursdayStartTime.Enabled = false;
            dtpThursdayEndTime.Enabled = false;



            cbxFriday.Checked = false;
            dtpFridayStartTime.Enabled = false;
            dtpFridayEndTime.Enabled = false;



            cbxSaturday.Checked = false;
            dtpSaturdayStartTime.Enabled = false;
            dtpSaturdayEndTime.Enabled = false;



            cbxSunday.Checked = false;
            dtpSundayStartTime.Enabled = false;
            dtpSundayEndTime.Enabled = false;
        }

        private void _LoadAndFillDoctorSchedules()
        {
            _dtDoctorSchedules = clsDoctorSchedule.GetDoctorSchedule(_Doctor.DoctorID);

            if (_dtDoctorSchedules == null || _dtDoctorSchedules.Rows.Count == 0)
                return; 

            foreach (DataRow row in _dtDoctorSchedules.Rows)
            {
                int dayOfWeek = Convert.ToInt32(row["DayOfWeek"]);
                TimeSpan startTime = (TimeSpan)row["StartTime"];
                TimeSpan endTime = (TimeSpan)row["EndTime"];

                DateTime startDateTime = DateTime.Today.Add(startTime);
                DateTime endDateTime = DateTime.Today.Add(endTime);

                switch (dayOfWeek)
                {
                    
                    case 1:
                        cbxMonday.Checked = true;
                        dtpMondayStartTime.Value = startDateTime;
                        dtpMondayEndTime.Value = endDateTime;
                        break;
                    case 2:
                        cbxTuesday.Checked = true;
                        dtpTuesdayStartTime.Value = startDateTime;
                        dtpTuesdayEndTime.Value = endDateTime;
                        break;
                    case 3:
                        cbxWednesday.Checked = true;
                        dtpWednesdayStartTime.Value = startDateTime;
                        dtpWednesdayEndTime.Value = endDateTime;
                        break;
                    case 4:
                        cbxThursday.Checked = true;
                        dtpThursdayStartTime.Value = startDateTime;
                        dtpThursdayEndTime.Value = endDateTime;
                        break;
                    case 5: 
                        cbxFriday.Checked = true;
                        dtpFridayStartTime.Value = startDateTime;
                        dtpFridayEndTime.Value = endDateTime;
                        break;
                    case 6:
                        cbxSaturday.Checked = true;
                        dtpSaturdayStartTime.Value = startDateTime;
                        dtpSaturdayEndTime.Value = endDateTime;
                        break;
                    case 7:
                        cbxSunday.Checked = true;
                        dtpSundayStartTime.Value = startDateTime;
                        dtpSundayEndTime.Value = endDateTime;
                        break;
                }
            }
        }

        private void ManageDoctorSchadule_Load(object sender, EventArgs e)
        {
            _Doctor = clsDoctor.Find(_DoctorID);

            if (_Doctor == null)
            {
                MessageBox.Show("There Is No Doctor Found","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblDoctorID.Text = _Doctor.DoctorID.ToString();
            lblDoctorName.Text = _Doctor.PersonInfo.FullName;
            lblDoctorSpecialty.Text = _Doctor.DoctorSpecialty.SpecialtyName;

            ResetAllControls();
            _LoadAndFillDoctorSchedules();
        }

        private void cbxMonday_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxMonday.Checked)
            {
                dtpMondayStartTime.Enabled = true;
                dtpMondayEndTime.Enabled = true;
            }
            else
            {
                dtpMondayStartTime.Enabled = false;
                dtpMondayEndTime.Enabled = false;
            }
        }

        private void cbxSaturday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSaturday.Checked)
            {
                dtpSaturdayStartTime.Enabled = true;
                dtpSaturdayEndTime.Enabled = true;
            }
            else
            {
                dtpSaturdayStartTime.Enabled = false;
                dtpSaturdayEndTime.Enabled = false;
            }
        }

        private void cbxWednesday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxWednesday.Checked)
            {
                dtpWednesdayStartTime.Enabled = true;
                dtpWednesdayEndTime.Enabled = true;
            }
            else
            {
                dtpWednesdayStartTime.Enabled = false;
                dtpWednesdayEndTime.Enabled = false;
            }
        }

        private void cbxThursday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxThursday.Checked)
            {
                dtpThursdayStartTime.Enabled = true;
                dtpThursdayEndTime.Enabled = true;
            }
            else
            {
                dtpThursdayStartTime.Enabled = false;
                dtpThursdayEndTime.Enabled = false;
            }
        }

        private void cbxFriday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFriday.Checked)
            {
                dtpFridayStartTime.Enabled = true;
                dtpFridayEndTime.Enabled = true;
            }
            else
            {
                dtpFridayStartTime.Enabled = false;
                dtpFridayEndTime.Enabled = false;
            }
        }

        private void cbxTuesday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTuesday.Checked)
            {
                dtpTuesdayStartTime.Enabled = true;
                dtpTuesdayEndTime.Enabled = true;
            }
            else
            {
                dtpTuesdayStartTime.Enabled = false;
                dtpTuesdayEndTime.Enabled = false;
            }
        }

        private void cbxSunday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSunday.Checked)
            {
                dtpSundayStartTime.Enabled = true;
                dtpSundayEndTime.Enabled = true;
            }
            else
            {
                dtpSundayStartTime.Enabled = false;
                dtpSundayEndTime.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            List<clsDoctorSchedule> scheduList = new List<clsDoctorSchedule>();

            if(cbxMonday.Checked)
            {
                scheduList.Add(new clsDoctorSchedule
                {
                    DoctorID = _Doctor.DoctorID,
                    DayOfWeek = 1,
                    StartTime = dtpMondayStartTime.Value.TimeOfDay,
                    EndTime = dtpMondayEndTime.Value.TimeOfDay
                }
                );
            }
            if (cbxTuesday.Checked)
            {
                scheduList.Add(new clsDoctorSchedule
                {
                    DoctorID = _Doctor.DoctorID,
                    DayOfWeek = 2,
                    StartTime = dtpTuesdayStartTime.Value.TimeOfDay,
                    EndTime = dtpTuesdayEndTime.Value.TimeOfDay
                }
                );
            }
            if (cbxWednesday.Checked)
            {
                scheduList.Add(new clsDoctorSchedule
                {
                    DoctorID = _Doctor.DoctorID,
                    DayOfWeek = 3,
                    StartTime = dtpWednesdayStartTime.Value.TimeOfDay,
                    EndTime = dtpWednesdayEndTime.Value.TimeOfDay
                }
                );
            }
            if (cbxThursday.Checked)
            {
                scheduList.Add(new clsDoctorSchedule
                {
                    DoctorID = _Doctor.DoctorID,
                    DayOfWeek = 4,
                    StartTime = dtpThursdayStartTime.Value.TimeOfDay,
                    EndTime = dtpThursdayEndTime.Value.TimeOfDay
                }
                );
            }
            if (cbxFriday.Checked)
            {
                scheduList.Add(new clsDoctorSchedule
                {
                    DoctorID = _Doctor.DoctorID,
                    DayOfWeek = 5,
                    StartTime = dtpFridayStartTime.Value.TimeOfDay,
                    EndTime = dtpFridayEndTime.Value.TimeOfDay
                }
                );
            }
            if (cbxSaturday.Checked)
            {
                scheduList.Add(new clsDoctorSchedule
                {
                    DoctorID = _Doctor.DoctorID,
                    DayOfWeek = 6,
                    StartTime = dtpSaturdayStartTime.Value.TimeOfDay,
                    EndTime = dtpSaturdayEndTime.Value.TimeOfDay
                }
                );
            }
            if (cbxSunday.Checked)
            {
                scheduList.Add(new clsDoctorSchedule
                {
                    DoctorID = _Doctor.DoctorID,
                    DayOfWeek = 7,
                    StartTime = dtpSundayStartTime.Value.TimeOfDay,
                    EndTime = dtpSundayEndTime.Value.TimeOfDay
                }
                );
            }


            clsDoctorSchedule.DeleteSchedulesByDoctorID(_Doctor.DoctorID);


            bool IsAllSaved = true;

            foreach(var i in scheduList)
            {
                if(!i.Save())
                {
                    IsAllSaved = false;
                }
            }

            if(IsAllSaved)
            {
                MessageBox.Show("All Working Days And Hours Has Been Saved Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed Saving All Working Days And Hours");
            }
        }
    }
}
