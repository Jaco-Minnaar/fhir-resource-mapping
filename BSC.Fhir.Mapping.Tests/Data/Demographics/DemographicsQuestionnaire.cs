using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BSC.Fhir.Mapping.Tests.Data;

public partial class Demographics
{
    public static Questionnaire CreateQuestionnaire()
    {
        var parser = new FhirJsonParser();
        var json = """
            {
              "resourceType": "Questionnaire",
              "id": "demographics",
              "meta": {
                "profile": [
                  "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-extr-defn"
                ]
              },
              "extension": [
                {
                  "extension": [
                    {
                      "url": "name",
                      "valueCoding": {
                        "system": "http://hl7.org/fhir/uv/sdc/CodeSystem/launchContext",
                        "code": "patient"
                      }
                    },
                    {
                      "url": "type",
                      "valueCode": "Patient"
                    }
                  ],
                  "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-launchContext"
                },
                {
                  "extension": [
                    {
                      "url": "name",
                      "valueCoding": {
                        "system": "http://hl7.org/fhir/uv/sdc/CodeSystem/launchContext",
                        "code": "user"
                      }
                    },
                    {
                      "url": "type",
                      "valueCode": "Practitioner"
                    }
                  ],
                  "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-launchContext"
                },
                {
                  "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-itemExtractionContext",
                  "valueExpression": {
                    "language": "application/x-fhir-query",
                    "expression": "Patient?_id={{%patient.id}}"
                  }
                }
              ],
              "url": "http://hl7.org/fhir/uv/sdc/Questionnaire/demographics",
              "version": "3.0.0",
              "name": "DemographicExample",
              "title": "Questionnaire - Demographics Example",
              "status": "draft",
              "experimental": true,
              "subjectType": ["Patient"],
              "date": "2022-10-01T05:09:13+00:00",
              "publisher": "HL7 International - FHIR Infrastructure Work Group",
              "contact": [
                {
                  "telecom": [
                    {
                      "system": "url",
                      "value": "http://hl7.org/Special/committees/fiwg"
                    }
                  ]
                }
              ],
              "description": "A sample questionnaire using context-based population and extraction",
              "jurisdiction": [
                {
                  "coding": [
                    {
                      "system": "http://unstats.un.org/unsd/methods/m49/m49.htm",
                      "code": "001"
                    }
                  ]
                }
              ],
              "item": [
                {
                  "extension": [
                    {
                      "url": "http://hl7.org/fhir/StructureDefinition/questionnaire-hidden",
                      "valueBoolean": true
                    },
                    {
                      "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                      "valueExpression": {
                        "language": "text/fhirpath",
                        "expression": "%patient.id"
                      }
                    }
                  ],
                  "linkId": "patient.id",
                  "definition": "Patient.id",
                  "text": "(internal use)",
                  "type": "string",
                  "readOnly": true
                },
                {
                  "extension": [
                    {
                      "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                      "valueExpression": {
                        "language": "text/fhirpath",
                        "expression": "%patient.birthDate"
                      }
                    }
                  ],
                  "linkId": "patient.birthDate",
                  "definition": "Patient.birthDate",
                  "text": "Date of birth",
                  "type": "date",
                  "required": true
                },
                {
                  "linkId": "patient.active",
                  "definition": "Patient.active",
                  "text": "active?",
                  "type": "boolean",
                  "required": true
                },
                {
                  "extension": [
                    {
                      "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                      "valueExpression": {
                        "language": "text/fhirpath",
                        "expression": "%patient.gender"
                      }
                    }
                  ],
                  "linkId": "patient.gender",
                  "definition": "Patient.gender",
                  "text": "gender",
                  "type": "choice",
                  "required": true
                },
                {
                  "extension": [
                    {
                      "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-itemPopulationContext",
                      "valueExpression": {
                        "name": "patientName",
                        "language": "text/fhirpath",
                        "expression": "%patient.name"
                      }
                    }
                  ],
                  "linkId": "patient.name",
                  "definition": "Patient.name",
                  "text": "Name(s)",
                  "type": "group",
                  "repeats": true,
                  "item": [
                    {
                      "extension": [
                        {
                          "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                          "valueExpression": {
                            "language": "text/fhirpath",
                            "expression": "%patientName.family"
                          }
                        }
                      ],
                      "linkId": "patient.name.family",
                      "definition": "Patient.name.family",
                      "text": "Family name",
                      "type": "string",
                      "required": true
                    },
                    {
                      "extension": [
                        {
                          "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                          "valueExpression": {
                            "language": "text/fhirpath",
                            "expression": "%patientName.given"
                          }
                        }
                      ],
                      "linkId": "patient.name.given",
                      "definition": "Patient.name.given",
                      "text": "Given name(s)",
                      "type": "string",
                      "required": true,
                      "repeats": true
                    }
                  ]
                },
                {
                  "extension": [
                    {
                      "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-itemPopulationContext",
                      "valueExpression": {
                        "name": "relatedPerson",
                        "language": "application/x-fhir-query",
                        "expression": "RelatedPerson?patient={{%patient.id}}"
                      }
                    },
                    {
                      "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-itemExtractionContext",
                      "valueExpression": {
                        "language": "application/x-fhir-query",
                        "expression": "RelatedPerson?patient={{%patient.id}}"
                      }
                    },
                    {
                      "url": "extractionContextId",
                      "valueExpression": {
                        "language": "text/fhirpath",
                        "expression": "%context.item.where(linkId='relative.id').answer.value"
                      }
                    }
                  ],
                  "linkId": "relative",
                  "text": "Relatives, caregivers and other personal relationships",
                  "type": "group",
                  "repeats": true,
                  "item": [
                    {
                      "extension": [
                        {
                          "url": "http://hl7.org/fhir/StructureDefinition/questionnaire-hidden",
                          "valueBoolean": true
                        },
                        {
                          "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                          "valueExpression": {
                            "language": "text/fhirpath",
                            "expression": "%relatedPerson.id"
                          }
                        }
                      ],
                      "linkId": "relative.id",
                      "definition": "RelatedPerson.id",
                      "text": "(internal use)",
                      "type": "string",
                      "readOnly": true
                    },
                    {
                      "extension": [
                        {
                          "url": "http://hl7.org/fhir/StructureDefinition/questionnaire-hidden",
                          "valueBoolean": true
                        },
                        {
                          "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                          "valueExpression": {
                            "language": "text/fhirpath",
                            "expression": "%relatedPerson.patient"
                          }
                        },
                        {
                          "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition-sdc-questionnaire-calculatedExpression.html",
                          "valueExpression": {
                            "language": "text/fhirpath",
                            "expression": "%patient.id"
                          }
                        },
                      ],
                      "linkId": "relative.patient",
                      "definition": "RelatedPerson.patient",
                      "text": "(internal use)",
                      "type": "reference",
                      "readOnly": true
                    },
                    {
                      "extension": [
                        {
                          "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                          "valueExpression": {
                            "language": "text/fhirpath",
                            "expression": "%relatedPerson.relationship"
                          }
                        }
                      ],
                      "linkId": "relative.relationship",
                      "definition": "RelatedPerson.relationship",
                      "text": "Name(s)",
                      "type": "choice",
                      "required": true,
                      "repeats": true,
                      "answerValueSet": "http://hl7.org/fhir/ValueSet/relatedperson-relationshiptype"
                    },
                    {
                      "extension": [
                        {
                          "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-itemPopulationContext",
                          "valueExpression": {
                            "name": "relativeName",
                            "language": "text/fhirpath",
                            "expression": "%relatedPerson.name"
                          }
                        }
                      ],
                      "linkId": "relative.name",
                      "definition": "RelatedPerson.name",
                      "text": "Name(s)",
                      "type": "group",
                      "repeats": true,
                      "item": [
                        {
                          "extension": [
                            {
                              "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                              "valueExpression": {
                                "language": "text/fhirpath",
                                "expression": "%relativeName.family"
                              }
                            }
                          ],
                          "linkId": "relative.name.family",
                          "definition": "RelatedPerson.name.family",
                          "text": "Family name",
                          "type": "string",
                          "required": true
                        },
                        {
                          "extension": [
                            {
                              "url": "http://hl7.org/fhir/uv/sdc/StructureDefinition/sdc-questionnaire-initialExpression",
                              "valueExpression": {
                                "language": "text/fhirpath",
                                "expression": "%relativeName.given"
                              }
                            }
                          ],
                          "linkId": "relative.name.given",
                          "definition": "RelatedPerson.name.given",
                          "text": "Given name(s)",
                          "type": "string",
                          "required": true,
                          "repeats": true
                        }
                      ]
                    }
                  ]
                }
              ]
            }
""";

        var result = parser.Parse<Questionnaire>(json);

        var i = result.Item.FirstOrDefault(u => u.LinkId == "patient.active");
        if (i != null)
        {
            i.Initial = new List<Questionnaire.InitialComponent>
            {
                new Questionnaire.InitialComponent() { Value = new FhirBoolean(true) }
            };
        }

        return result;
    }
}
