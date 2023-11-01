using BSC.Fhir.Mapping.Core;
using Hl7.Fhir.Model;

namespace BSC.Fhir.Mapping.Expressions;

using BaseList = IReadOnlyCollection<Base>;

public class ScopeTree
{
    private Scope<BaseList> _currentScope;
    private readonly INumericIdProvider _idProvider;

    public Questionnaire.ItemComponent? CurrentItem => _currentScope?.Item;
    public QuestionnaireResponse.ItemComponent? CurrentResponseItem => _currentScope?.ResponseItem;
    public Scope<BaseList> CurrentScope => _currentScope;

    public ScopeTree(
        Questionnaire questionnaire,
        QuestionnaireResponse? questionnaireResponse,
        INumericIdProvider idProvider
    )
    {
        _idProvider = idProvider;
        _currentScope = new(idProvider, questionnaire, questionnaireResponse);
    }

    public void PushScope(Questionnaire.ItemComponent item)
    {
        _currentScope = new(item, _currentScope, _idProvider);
    }

    public void PushScope(Questionnaire.ItemComponent item, QuestionnaireResponse.ItemComponent responseItem)
    {
        _currentScope = new(item, responseItem, _currentScope, _idProvider);
    }

    public bool PopScope()
    {
        if (_currentScope.Parent is null)
        {
            return false;
        }

        _currentScope = _currentScope.Parent;
        return true;
    }

    public static Scope<BaseList>? GetScope(string linkId, Scope<BaseList> scope)
    {
        if (scope.Item?.LinkId == linkId)
        {
            return scope;
        }

        foreach (var child in scope.Children)
        {
            if (GetScope(linkId, child) is Scope<BaseList> found)
            {
                return found;
            }
        }

        return null;
    }
}
