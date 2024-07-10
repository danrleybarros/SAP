{{/*
Expand the name of the chart.
*/}}
{{- define "gcsb-connect-sap.name" -}}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Create a default fully qualified app name.
We truncate at 63 chars because some Kubernetes name fields are limited to this (by the DNS naming spec).
If release name contains chart name it will be used as a full name.
*/}}
{{- define "gcsb-connect-sap.fullname" -}}
{{- if .Values.fullnameOverride }}
{{- .Values.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := default .Chart.Name .Values.nameOverride }}
{{- if contains $name .Release.Name }}
{{- .Release.Name | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "gcsb-connect-sap.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "gcsb-connect-sap.labels" -}}
helm.sh/chart: {{ include "gcsb-connect-sap.chart" . }}
{{ include "gcsb-connect-sap.selectorLabels" . }}
{{- if .Chart.AppVersion }}
app.kubernetes.io/version: {{ .Chart.AppVersion | quote }}
{{- end }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "gcsb-connect-sap.selectorLabels" -}}
app.kubernetes.io/name: {{ include "gcsb-connect-sap.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "gcsb-connect-sap.selectorLabels-apiconfig" -}}
app.kubernetes.io/name: {{ include "gcsb-connect-sap.name" . }}-apiconfig
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "gcsb-connect-sap.selectorLabels-movefile" -}}
app.kubernetes.io/name: {{ include "gcsb-connect-sap.name" . }}-movefile
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "gcsb-connect-sap.selectorLabels-readfile" -}}
app.kubernetes.io/name: {{ include "gcsb-connect-sap.name" . }}-readfile
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "gcsb-connect-sap.selectorLabels-writefile" -}}
app.kubernetes.io/name: {{ include "gcsb-connect-sap.name" . }}-writefile
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

{{/*
Create the name of the service account to use
*/}}
{{- define "gcsb-connect-sap.serviceAccountName" -}}
{{- if .Values.serviceAccount.create }}
{{- default (include "gcsb-connect-sap.fullname" .) .Values.serviceAccount.name }}
{{- else }}
{{- default "default" .Values.serviceAccount.name }}
{{- end }}
{{- end }}
