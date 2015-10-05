using System.Collections;
using UnityEditor;
using UnityEngine;

public class ModelObjectBehavior : MonoBehaviour {
	public bool HP;
	public int MaxHP;
	public int MinHP;
	public GameObject PrefabDesenhoHP;
	public bool XP;
	public int MaxXP;
	public int MinXP;
	public GameObject PrefabDesenhoXP;
    public bool Velocidade;
    public int MaxVelocidade;
    public int MinVelocidade;
    public GameObject PrefabDesenhoVelocidade;
    public bool Level;
    public int MaxLevel;
    public int MinLevel;
    public GameObject PrefabDesenhoLevel;
    public bool ObjTiro;
    public GameObject PrefabDesenhoObjTiro;
    public bool Dano;
    public int MaxDano;
    public int MinDano;
    public GameObject PrefabDesenhoDano;
    public bool Acerto;
    public int MaxAcerto;
    public int MinAcerto;
    public GameObject PrefabDesenhoAcerto;
    public bool Critico;
    public int MaxCritico;
    public int MinCritico;
    public GameObject PrefabDesenhoCritico;
    public bool TempoRecarga;
    public int MaxTempoRecarga;
    public int MinTempoRecarga;
    public GameObject PrefabDesenhoTempoRecarga;
}
	[CustomEditor(typeof(ModelObjectBehavior))]

public class ModelObjectBehaviorEditor : Editor
{
	public override void  OnInspectorGUI()
	{
		var modelObjectBehavior = target as ModelObjectBehavior;
		modelObjectBehavior.HP = GUILayout.Toggle (modelObjectBehavior.HP, "HP");
		if (modelObjectBehavior.HP) {
			modelObjectBehavior.PrefabDesenhoHP = EditorGUILayout.ObjectField ("    PrefabDesenhoHP",modelObjectBehavior.PrefabDesenhoHP, typeof(GameObject)) as GameObject;
			modelObjectBehavior.MaxHP = EditorGUILayout.IntField ("    MaxHP",modelObjectBehavior.MaxHP);
			modelObjectBehavior.MinHP = EditorGUILayout.IntField("    MinHP",modelObjectBehavior.MinHP);
		}
		modelObjectBehavior.XP = GUILayout.Toggle (modelObjectBehavior.XP, "XP");
		if (modelObjectBehavior.XP) {
			modelObjectBehavior.PrefabDesenhoXP = EditorGUILayout.ObjectField ("    PrefabDesenhoXP",modelObjectBehavior.PrefabDesenhoXP, typeof(GameObject)) as GameObject;
			modelObjectBehavior.MaxXP = EditorGUILayout.IntField ("    MaxXP",modelObjectBehavior.MaxXP);
			modelObjectBehavior.MinXP = EditorGUILayout.IntField("    MinXP",modelObjectBehavior.MinXP);
		}
        modelObjectBehavior.Velocidade = GUILayout.Toggle(modelObjectBehavior.Velocidade, "Velocidade");
        if (modelObjectBehavior.Velocidade)
        {
            modelObjectBehavior.PrefabDesenhoVelocidade = EditorGUILayout.ObjectField("    PrefabDesenhoVelocidade", modelObjectBehavior.PrefabDesenhoVelocidade, typeof(GameObject)) as GameObject;
            modelObjectBehavior.MaxVelocidade = EditorGUILayout.IntField("    MaxVelocidade", modelObjectBehavior.MaxVelocidade);
            modelObjectBehavior.MinVelocidade = EditorGUILayout.IntField("    MinVelocidade", modelObjectBehavior.MinVelocidade);
        }
        modelObjectBehavior.Level = GUILayout.Toggle(modelObjectBehavior.Level, "Level");
        if (modelObjectBehavior.Level)
        {
            modelObjectBehavior.PrefabDesenhoLevel = EditorGUILayout.ObjectField("    PrefabDesenhoLevel", modelObjectBehavior.PrefabDesenhoLevel, typeof(GameObject)) as GameObject;
            modelObjectBehavior.MaxLevel = EditorGUILayout.IntField("    MaxLevel", modelObjectBehavior.MaxLevel);
            modelObjectBehavior.MinLevel = EditorGUILayout.IntField("    MinLevel", modelObjectBehavior.MinLevel);
        }
        modelObjectBehavior.ObjTiro = GUILayout.Toggle(modelObjectBehavior.ObjTiro, "ObjTiro");
        if (modelObjectBehavior.ObjTiro)
        {
            modelObjectBehavior.PrefabDesenhoObjTiro = EditorGUILayout.ObjectField("    PrefabDesenhoObjTiro", modelObjectBehavior.PrefabDesenhoObjTiro, typeof(GameObject)) as GameObject;
        }
        modelObjectBehavior.Dano = GUILayout.Toggle(modelObjectBehavior.Dano, "Dano");
        if (modelObjectBehavior.Dano)
        {
            modelObjectBehavior.PrefabDesenhoDano = EditorGUILayout.ObjectField("    PrefabDesenhoDano", modelObjectBehavior.PrefabDesenhoDano, typeof(GameObject)) as GameObject;
            modelObjectBehavior.MaxDano = EditorGUILayout.IntField("    MaxDano", modelObjectBehavior.MaxDano);
            modelObjectBehavior.MinDano = EditorGUILayout.IntField("    MinDano", modelObjectBehavior.MinDano);
        }
        modelObjectBehavior.Acerto = GUILayout.Toggle(modelObjectBehavior.Acerto, "Acerto");
        if (modelObjectBehavior.Acerto)
        {
            modelObjectBehavior.PrefabDesenhoAcerto = EditorGUILayout.ObjectField("    PrefabDesenhoAcerto", modelObjectBehavior.PrefabDesenhoAcerto, typeof(GameObject)) as GameObject;
            modelObjectBehavior.MaxAcerto = EditorGUILayout.IntField("    MaxAcerto", modelObjectBehavior.MaxAcerto);
            modelObjectBehavior.MinAcerto = EditorGUILayout.IntField("    MinAcerto", modelObjectBehavior.MinAcerto);
        }
        modelObjectBehavior.Critico = GUILayout.Toggle(modelObjectBehavior.Critico, "Critico");
        if (modelObjectBehavior.Critico)
        {
            modelObjectBehavior.PrefabDesenhoCritico = EditorGUILayout.ObjectField("    PrefabDesenhoCritico", modelObjectBehavior.PrefabDesenhoCritico, typeof(GameObject)) as GameObject;
            modelObjectBehavior.MaxCritico = EditorGUILayout.IntField("    MaxCritico", modelObjectBehavior.MaxCritico);
            modelObjectBehavior.MinCritico = EditorGUILayout.IntField("    MinCritico", modelObjectBehavior.MinCritico);
        }
        modelObjectBehavior.TempoRecarga = GUILayout.Toggle(modelObjectBehavior.TempoRecarga, "TempoRecarga");
        if (modelObjectBehavior.TempoRecarga)
        {
            modelObjectBehavior.PrefabDesenhoTempoRecarga = EditorGUILayout.ObjectField("    PrefabDesenhoTempoRecarga", modelObjectBehavior.PrefabDesenhoTempoRecarga, typeof(GameObject)) as GameObject;
            modelObjectBehavior.MaxTempoRecarga = EditorGUILayout.IntField("    MaxTempoRecarga", modelObjectBehavior.MaxTempoRecarga);
            modelObjectBehavior.MinTempoRecarga = EditorGUILayout.IntField("    MinTempoRecarga", modelObjectBehavior.MinTempoRecarga);
        }
    }
}
