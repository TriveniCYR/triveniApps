$(document).ready(function () {
    function adjustIframeHeight() {
        var $body = $('body'),
            $iframe = $body.data('iframe.fv');
        if ($iframe) {
            // Adjust the height of iframe
            $iframe.height($body.height());
        }
    }


    // IMPORTANT: You must call .steps() before calling .formValidation()
    $('#profileForm')
        .steps({
            headerTag: 'h2',
            bodyTag: 'section',
            onStepChanged: function (e, currentIndex, priorIndex) {
                // You don't need to care about it
                // It is for the specific demo
                adjustIframeHeight();
            },
            // Triggered when clicking the Previous/Next buttons
            onStepChanging: function (e, currentIndex, newIndex) {
                var fv = $('#profileForm').data('formValidation'), // FormValidation instance
                    // The current step container
                    $container = $('#profileForm').find('section[data-step="' + currentIndex + '"]');

                // Validate the container
                fv.validateContainer($container);

                var isValidStep = fv.isValidContainer($container);
                if (isValidStep === false || isValidStep === null) {
                    // Do not jump to the next step
                    return false;
                }

                return true;
            },
            // Triggered when clicking the Finish button
            onFinishing: function (e, currentIndex) {
                var fv = $('#profileForm').data('formValidation'),
                    $container = $('#profileForm').find('section[data-step="' + currentIndex + '"]');

                // Validate the last step container
                fv.validateContainer($container);

                var isValidStep = fv.isValidContainer($container);
                if (isValidStep === false || isValidStep === null) {
                    return false;
                }

                return true;
            },
            onFinished: function (e, currentIndex) {
                // Uncomment the following line to submit the form using the defaultSubmit() method
                $('#profileForm').formValidation('defaultSubmit');

                // For testing purpose
                //$('#welcomeModal').modal();
            }
        })
        .formValidation({
            framework: 'bootstrap',
            icon: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            // This option will not ignore invisible fields which belong to inactive panels
            excluded: ':disabled',
            fields: {

                'PersonViewModel.FirstName': {
                    //row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The first name is required'
                        },
                        regexp: {
                            regexp: /^[a-zA-Z\s]+$/,
                            message: 'The first name can only consist of alphabetical and space'
                        }
                    }
                },
                'PersonViewModel.LastName': {
                    //row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The last name is required'
                        },
                        regexp: {
                            regexp: /^[a-zA-Z\s]+$/,
                            message: 'The last name can only consist of alphabetical and space'
                        }
                    }
                },

                'PersonViewModel.DOB': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The birthday is required'
                        },
                        date: {
                            format: 'DD/MM/YYYY',
                            message: 'The birthday is not valid'
                        }
                    }
                },
                'PersonViewModel.SeatId': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Seat Id is required'
                        }
                    }
                },
                'PersonViewModel.EquipmentID': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Equipment Id is required'
                        }
                    }
                },
                'PersonViewModel.AveFlyHours': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The AveFlyHours is required'
                        },
                        regexp: {
                            regexp: /^\d+$/i,
                            message: 'AveFlyHours should be Number'
                        }
                    }
                },
                'AddressViewModel.AddressLine1': {
                    row: '.col-xs-8',
                    validators: {
                        notEmpty: {
                            message: 'The AddressLine1 is required'
                        }
                    }
                },
                'AddressViewModel.City': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The City is required'
                        }
                    }
                },
                'AddressViewModel.StateId': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The State Id is required'
                        }
                    }
                },
                'AddressViewModel.ZipCode': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Zip Code is required'
                        },
                        regexp: {
                            regexp: /^\d{5}(-\d{4})?$/i,
                            message: 'Zip Code is not valid'
                        }
                    }
                },
                'AddressViewModel.HomePhone': {
                    row: '.col-xs-4',
                    validators: {

                        regexp: {
                            regexp: /^[0-9]{3}-[0-9]{3}-[0-9]{4}$/i,
                            message: 'Home Phone is not valid'
                        }
                    }
                },
                'AddressViewModel.MobilePhone': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Mobile Phone is required'
                        },
                        regexp: {
                            regexp: /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/i,
                            message: 'Mobile Phone is not valid'
                        }
                    }
                },
                'AddressViewModel.Email': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Email is required'
                        }

                    }
                },
                'AddressViewModel.Fax': {
                    row: '.col-xs-4',
                    validators: {

                        regexp: {
                            regexp: /^\d{5}(-\d{4})?$/i,
                            message: 'Fax is not valid'
                        }
                    }
                },

                //////////PersonFinancial Validation Field
                'PersonFinancialViewModel.Balance401KAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Balance 401K Amount is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Balance 401K Amount is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.CompanyContributionAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Company Contribution Amount is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Company Contribution Amount is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.ProjectedRetuPer': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Projected Return Amount is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Projected Return Amount is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.OtherIRAbalanceAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Other IRA balance Amount is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Other IRA balance Amount is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.AnnualIRAContributionAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Annual IRA Contribution Amount is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Annual IRA Contribution Amount is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.TaxableAccountBal': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Taxable Account Balances is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Taxable Account Balances is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.TaxableAccountContributions': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Taxable Account Contributions is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Taxable Account Contributions is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.MilitaryAnnuity': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Military Annuity is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Military Annuity is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.MilitarySurvivorAnnuity': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Military Survivor Annuity is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Military Survivor Annuity is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.FundAnnuityAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Fund Annuity Amount is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Fund Annuity Amount is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.WithdrawRatePer': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Withdraw Rate is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Withdraw Rate is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SSBeniftAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Security Benift Amount is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Security Benift Amount is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SpouseSSBenifitAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Spouse Social Security Benifit  is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Spouse Social Security Benifit is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SSProjAge': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Projected Social Security age is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Projected Social Security age is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SSProjAge': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Projected Social Security age is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Projected Social Security age is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SSSpouseProjAge': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Projected Spouse Social Security age is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Projected Spouse Social Security age is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.Spouse401kBalance': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Spouse 401k balance is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Spouse 401k balance is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SpouseIRABalance': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The spouse IRA balance is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'spouse IRA balance is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SpouseAnnualIRAProjAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Spouse annual IRA projected is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Spouse annual IRA projected is not valid'
                        }
                    }
                },
                'PersonFinancialViewModel.SpouseAnnuityAmount': {
                    row: '.col-xs-4',
                    validators: {
                        notEmpty: {
                            message: 'The Spouse Annuity is required'
                        },
                        regexp: {
                            regexp: /^\d+(\.\d{1,2})?$/i,
                            message: 'Spouse Annuity is not valid'
                        }
                    }
                }


            }
        });
});