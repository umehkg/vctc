private static void MakeESPLine(Vector3 center, float x1, float y1, float z1, float x2, float y2, float z2, Color color)
{
	Vector3 pointPos1 = new Vector3(center.x + x1, center.y + y1, center.z + z1);
	Vector3 pointPos2 = new Vector3(center.x + x2, center.y + y2, center.z + z2);
	Vector3 xy1 = Camera.main.WorldToScreenPoint(pointPos1);
	Vector3 xy2 = Camera.main.WorldToScreenPoint(pointPos2);
	if ((xy1.z>0)&&(xy2.z>0))
		Drawing.DrawLine(new Vector2(xy1.x,Screen.height-xy1.y),new Vector2(xy2.x,Screen.height-xy2.y),color,1.0f,false);
}
private static void Make3DBox(Vector3 center, Vector3 size, Color color)
{
	//clockwise
	
	//bottom
	MakeESPLine(center, -size.x/2, -size.y/2, size.z/2, size.x/2, -size.y/2, size.z/2, color);
	MakeESPLine(center, size.x/2, -size.y/2, size.z/2, size.x/2, -size.y/2, -size.z/2, color);
	MakeESPLine(center, size.x/2, -size.y/2, -size.z/2, -size.x/2, -size.y/2, -size.z/2, color);
	MakeESPLine(center, -size.x/2, -size.y/2, -size.z/2, -size.x/2, -size.y/2, size.z/2, color);

	//middle
	MakeESPLine(center, -size.x/2, -size.y/2, size.z/2, -size.x/2, size.y/2, size.z/2, color);
	MakeESPLine(center, size.x/2, -size.y/2, size.z/2, size.x/2, size.y/2, size.z/2, color);
	MakeESPLine(center, size.x/2, -size.y/2, -size.z/2, size.x/2, size.y/2, -size.z/2, color);
	MakeESPLine(center, -size.x/2, -size.y/2, -size.z/2, -size.x/2, size.y/2, -size.z/2, color);

	//top
	MakeESPLine(center, -size.x/2, size.y/2, size.z/2, size.x/2, size.y/2, size.z/2, color);
	MakeESPLine(center, size.x/2, size.y/2, size.z/2, size.x/2, size.y/2, -size.z/2, color);
	MakeESPLine(center, size.x/2, size.y/2, -size.z/2, -size.x/2, size.y/2, -size.z/2, color);
	MakeESPLine(center, -size.x/2, size.y/2, -size.z/2, -size.x/2, size.y/2, size.z/2, color);
}
