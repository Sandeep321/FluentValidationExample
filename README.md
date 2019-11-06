# FluentValidationExample

It is a sample repo to reproduce the issue detailed at https://github.com/JeremySkinner/FluentValidation/issues/1255


It looks like an issue with FluentValidator where it invokes WithMessage irrespective of whether the validation for a rule has failed or passed.

Repro steps:
Clone the repo.
Run the API, it should open "https://localhost:44363/swagger/index.html" by default.
Execute POST - /api/Values/Test with default values in body as: { "id": 0, "name": "string"}
In response, you shall see only one element in errors collection as - Student Id should be greater than 100 (Response is as expected as only one rule is failed)
However, if you put debugger inside Localizer.GetLocalizedString(string message), you will see that it gets invoked for both the rules defined under StudentViewModelValidator. Although only one rule has failed.
I have tried different options to disable client-side validation. You can check those Options as Option 1, Option 2 and Option 3 inside Startup file.
