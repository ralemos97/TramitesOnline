<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <!-- Determino que el formato se aplica a todo el documento-->
  <xsl:template match="TipoTramite">

    <!--Creo una tabla para poder desplegar prolijamente-->
    <table style="width: 40%;">
      <tr>
        <td class="margin-bottom-xs" style="width: 40%;">Codigo</td>
        <td class="margin-bottom-xs" style="width: 60%;">
          <xsl:value-of select="Codigo" />
        </td>
      </tr>

      <tr>
        <td class="margin-bottom-xs" style="width: 40%;"> Nombre </td>
        <td class="margin-bottom-xs" style="width: 60%;">
          <xsl:value-of select="Nombre"/>
        </td>
      </tr>

      <tr>
        <td class="margin-bottom-xs" style="width: 40%;"> Descripción </td>
        <td class="margin-bottom-xs" style="width: 60%;">
          <xsl:value-of select="Descripcion"/>
        </td>
      </tr>

      <tr>
        <td class="margin-bottom-xs" style="width: 40%;"> Precio </td>
        <td class="margin-bottom-xs" style="width: 60%;">
          <xsl:value-of select="Precio"/>
        </td>
      </tr>
    </table>
    
    <h5>Documentos requeridos</h5>

    <table style="width: 40%;">
      <thead>
        <tr>          
          <th class="text-align-left">Nombre</th>
          <th class="text-align-left">Lugar de solicitud</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="DocumentosRequeridos/Documento">
          <tr>            
            <td class="margin-bottom-xs" style="width: 40%;">
              <xsl:value-of select="Nombre"/>
            </td>
            <td class="margin-bottom-xs"  style="width: 60%;">
              <xsl:value-of select="LugarSolicitud"/>
            </td>
          </tr>
        </xsl:for-each>
      </tbody>
    </table>


  </xsl:template>

</xsl:stylesheet>
